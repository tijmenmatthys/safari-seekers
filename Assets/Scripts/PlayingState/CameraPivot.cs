using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1f;

    private PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerMovement.transform.position;
        RotateY();
    }

    private void RotateY()
    {
        var rotation = transform.rotation.eulerAngles;
        rotation.y = Mathf.LerpAngle(rotation.y, _playerMovement.PlayerRotation, _lerpSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
