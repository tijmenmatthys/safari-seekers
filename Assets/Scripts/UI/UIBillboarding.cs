using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboarding : MonoBehaviour
{
    [SerializeField]
    private GameObject _image;
    [SerializeField]
    private float _animalCheckDistanceThreshold = 8f;

    private GameObject _player;
    private Camera _mainCam;
    private Transform _imageTransform;


    private void Awake()
    {
        _imageTransform = _image.transform;
        _mainCam = Camera.main;
        _imageTransform = this.transform;
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance <= _animalCheckDistanceThreshold)
        {
            _image.SetActive(true);
            _image.transform.rotation = _mainCam.transform.rotation;
        } else
        {
            _image.SetActive(false);
        }
    }
}
