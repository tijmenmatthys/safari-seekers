using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimePickup : MonoBehaviour
{
    public TimePickupType Type;

    public UnityEvent PickupCollected;
    public UnityEvent PickupRespawned;

    public void Collect() => PickupCollected?.Invoke();

    public void Respawn() => PickupRespawned?.Invoke();
}
