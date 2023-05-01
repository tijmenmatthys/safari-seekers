using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteractUI : MonoBehaviour
{
    public void GetAnimalInteractable(Transform other)
    {
        other.gameObject.GetComponent<UIBillboarding>().ShowInteractButton();
    }

    public void GetAnimalNotInteractable(Transform other)
    {
        other.gameObject.GetComponent<UIBillboarding>().HideInteractButton();
    }
}
