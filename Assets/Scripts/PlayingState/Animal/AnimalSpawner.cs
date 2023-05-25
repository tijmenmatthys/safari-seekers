using Polyperfect.Animals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _animalPrefab;
    [SerializeField] private int _animalCount;
    [SerializeField] private List<Transform> _spawnPoints;

    private List<Transform> _freeSpawnPoints;
    private Dictionary<Animal, Transform> _occupiedSpawnPoints
        = new Dictionary<Animal, Transform>();

    public AnimalType AnimalType { get; private set; }

    private void Awake()
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
        
        _freeSpawnPoints = new List<Transform>(_spawnPoints);

        UpdateAfterStatChange();
    }
    public void UpdateAfterStatChange()
    {
        if (_animalCount > _spawnPoints.Count - 1)
        {
            Debug.LogError($"Not enough spawning points provided ({_spawnPoints.Count}) to handle the amount of animals ({_animalCount})");
            _animalCount = _spawnPoints.Count - 1;
        }
        SpawnAnimals();
    }

    public void Respawn(Animal foundAnimal)
    {
        Debug.Log(foundAnimal.name);
        var oldSpawn = _occupiedSpawnPoints[foundAnimal];
        var newSpawn = GetRandomFreeSpawn();

        _occupiedSpawnPoints[foundAnimal] = newSpawn;
        _freeSpawnPoints.Remove(newSpawn);
        _freeSpawnPoints.Add(oldSpawn);

        foundAnimal.GetComponent<NavMeshAgent>().Warp(newSpawn.position);
        foundAnimal.GetComponent<Animal_WanderScript>().ResetStartPosition();
    }

    private void SpawnAnimals()
    {
        for (int i = _occupiedSpawnPoints.Count; i < _animalCount; i++)
        {
            var spawn = GetRandomFreeSpawn();
            var animal = GameObject.Instantiate(_animalPrefab, transform).GetComponent<Animal>();
            animal.name = animal.AnimalType.ToString();

            _occupiedSpawnPoints[animal] = spawn;
            _freeSpawnPoints.Remove(spawn);

            //animal.transform.position = spawn.position;
            animal.GetComponent<NavMeshAgent>().Warp(spawn.position);
        }
    }

    private Transform GetRandomFreeSpawn()
    {
        int randomId = UnityEngine.Random.Range(0, _freeSpawnPoints.Count);
        return _freeSpawnPoints[randomId];
    }
}
