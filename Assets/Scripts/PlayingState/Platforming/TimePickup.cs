using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimePickup : MonoBehaviour
{
    public TimePickupType Type;

    public UnityEvent PickupCollected;

    public void OnCollected() => PickupCollected?.Invoke();
}
