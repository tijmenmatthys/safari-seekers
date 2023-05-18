using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField]
    private float _skyScrollSpeed;

    private float _currentRotation;

    private void Start()
    {
        _currentRotation = RenderSettings.skybox.GetFloat("_Rotation");
    }

    void Update()
    {
        _currentRotation += _skyScrollSpeed * Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation",_currentRotation );
    }
}
