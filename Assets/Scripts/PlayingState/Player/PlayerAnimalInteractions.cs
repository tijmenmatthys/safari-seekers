using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAnimalInteractions : MonoBehaviour
{
    public event Action<Animal> AnimalSelected;

    public UnityEvent<Transform> AnimalSelectable;
    public UnityEvent<Transform> AnimalNotSelectable;
    public UnityEvent OnPlayerSelectAnimal;

    [SerializeField] private LayerMask _animalLayerMask;

    private HashSet<Animal> _interactableAnimals = new HashSet<Animal>();

    private void OnTriggerEnter(Collider other)
    {
        if (!_animalLayerMask.Contains(other.gameObject.layer)) return;

        _interactableAnimals.Add(other.GetComponent<Animal>());
        AnimalSelectable?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_animalLayerMask.Contains(other.gameObject.layer)) return;

        _interactableAnimals.Remove(other.GetComponent<Animal>());
        AnimalNotSelectable?.Invoke(other.transform);
    }

    public void OnSelectAnimal(InputValue value)
    {
        if (_interactableAnimals.Count == 0) return;
        Animal selectedAnimal = GetClosestAnimal();
        OnPlayerSelectAnimal?.Invoke();
        _interactableAnimals.Remove(selectedAnimal);
        AnimalNotSelectable?.Invoke(selectedAnimal.transform);
        AnimalSelected?.Invoke(selectedAnimal);
    }

    private Animal GetClosestAnimal()
    {
        Animal closestAnimal = null;
        float closestDistance = float.PositiveInfinity;
        foreach (var animal in _interactableAnimals)
        {
            float distance = Vector3.Distance(transform.position, animal.transform.position);
            if (distance < closestDistance)
            {
                closestAnimal = animal;
                closestDistance = distance;
            }
        }
        return closestAnimal;
    }
}
