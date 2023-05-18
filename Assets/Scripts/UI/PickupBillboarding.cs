using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBillboarding : MonoBehaviour
{
    [SerializeField]
    private GameObject _image;

    private Camera _mainCam;
    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {

        if (_image.activeSelf)
            _image.transform.rotation = _mainCam.transform.rotation;
    }
}
