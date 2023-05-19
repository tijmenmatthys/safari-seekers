using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWhenInvisible : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDeactivate;

    private Behaviour[] _components;

    private void Start()
    {
        _components = _objectToDeactivate.GetComponents<Behaviour>();
    }

    private void OnBecameInvisible()
    {
        //_objectToDeactivate.SetActive(false);
        foreach (var component in _components)
            component.enabled = false;
    }
    private void OnBecameVisible()
    {
        //_objectToDeactivate.SetActive(true);
        foreach (var component in _components)
            component.enabled = true;
    }
}
