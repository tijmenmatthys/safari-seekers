using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private List<Transform> _spawnPoints;

    private CharacterController _playerCharacterController;
    private PlayerMovement _playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        _playerCharacterController = _player.GetComponent<CharacterController>();
        _playerMovement = _player.GetComponent<PlayerMovement>();

        Respawn();
    }

    private void Respawn()
    {
        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
        Transform spawn = _spawnPoints[randomIndex];

        _playerCharacterController.enabled = false;
        _player.transform.position = spawn.position;
        _playerMovement.PlayerRotation = spawn.rotation.eulerAngles.y;
        _playerCharacterController.enabled = true;
    }
}
