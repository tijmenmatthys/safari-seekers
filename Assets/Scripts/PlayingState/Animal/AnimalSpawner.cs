using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _animalPrefab;
    [SerializeField] private int _animalCount;
    [SerializeField] private List<Transform> _spawnPoints;

    private List<Transform> _freeSpawnPoints;
    private Dictionary<Animal, Transform> _occupiedSpawnPoints
        = new Dictionary<Animal, Transform>();

    public AnimalType AnimalType { get; private set; }

    private void OnValidate()
    {
        if (_animalPrefab == null) return;

        name = $"Animal Spawner - {_animalPrefab.name}";
        foreach (var spawn in _spawnPoints)
        {
            spawn.name = $"Spawn Point - {_animalPrefab.name}";
        }
        AnimalType = _animalPrefab.GetComponent<Animal>().AnimalType;
    }

    void Start()
    {
        if (_animalCount > _spawnPoints.Count - 1)
            Debug.LogError($"Not enough spawning points provided ({_spawnPoints.Count}) to handle the amount of animals ({_animalCount})");
        _freeSpawnPoints = new List<Transform>(_spawnPoints);

        InitialSpawn();
    }

    public void Respawn(Animal foundAnimal)
    {
        var oldSpawn = _occupiedSpawnPoints[foundAnimal];
        var newSpawn = GetRandomFreeSpawn();

        _occupiedSpawnPoints[foundAnimal] = newSpawn;
        _freeSpawnPoints.Remove(newSpawn);
        _freeSpawnPoints.Add(oldSpawn);

        foundAnimal.transform.position = newSpawn.position;
    }

    private void InitialSpawn()
    {
        for (int i = 0; i < _animalCount; i++)
        {
            var spawn = GetRandomFreeSpawn();
            var animal = GameObject.Instantiate(_animalPrefab, transform).GetComponent<Animal>();
            animal.name = animal.AnimalType.ToString();

            _occupiedSpawnPoints[animal] = spawn;
            _freeSpawnPoints.Remove(spawn);

            animal.transform.position = spawn.position;
        }
    }

    private Transform GetRandomFreeSpawn()
    {
        int randomId = UnityEngine.Random.Range(0, _freeSpawnPoints.Count);
        return _freeSpawnPoints[randomId];
    }
}
