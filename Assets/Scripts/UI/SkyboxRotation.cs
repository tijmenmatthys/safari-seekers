using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField]
    private float _skyScrollSpeed;

    private float _currentRotation;

    private Transform _mainCamTransform;

    private void Start()
    {
        _mainCamTransform = Camera.main.transform;   
    }

    private void Update()
    {
        _currentRotation += _skyScrollSpeed * Time.deltaTime;
        _mainCamTransform.rotation = Quaternion.Euler(_mainCamTransform.transform.rotation.eulerAngles.x, _currentRotation, _mainCamTransform.transform.rotation.eulerAngles.z);
    }
}
