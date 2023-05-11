using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask _pickupLayerMask;

    private Timer _timer;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_pickupLayerMask.Contains(other.gameObject.layer)) return;

        TimePickup pickup = other.gameObject.GetComponent<TimePickup>();
        pickup.Collect();
        _timer.OnPickupCollected(pickup.Type);
    }
}
