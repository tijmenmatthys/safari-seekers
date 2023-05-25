using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillzoneInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask _killzoneLayerMask;

    private SpawnPlayer _spawnPlayer;

    private void Awake()
    {
        _spawnPlayer = FindObjectOfType<SpawnPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_killzoneLayerMask.Contains(other.gameObject.layer)) return;

        _spawnPlayer.Respawn();
    }
}
