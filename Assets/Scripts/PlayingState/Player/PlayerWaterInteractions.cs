using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask _waterLayerMask;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnTriggerStay(Collider other)
    {
        if (!_waterLayerMask.Contains(other.gameObject.layer)) return;

        _playerMovement.IsWading = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_waterLayerMask.Contains(other.gameObject.layer)) return;

        _playerMovement.IsWading = false;
    }
}
