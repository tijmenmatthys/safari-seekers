using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboarding : MonoBehaviour
{
    [SerializeField]
    private GameObject _image;

    private Camera _mainCam;
    private bool _isActive;


    private void Awake()
    {
        _mainCam = Camera.main;
        _isActive = false;
    }

    private void Update()
    {

        if (_isActive)
        {
            _image.transform.rotation = _mainCam.transform.rotation;
        }
    }

    public void ShowInteractButton()
    {
        _image.SetActive(true);
        _isActive = true;
    }

    public void HideInteractButton()
    {
        _image.SetActive(false);
        _isActive = false;
    }
}
