using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CheckButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private void OnEnable()
    {
        this.gameObject.transform.localScale = Vector3.one;
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (eventData.selectedObject == this.gameObject)
        {
            LeanTween.scale(this.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.15f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (eventData.selectedObject == this.gameObject)
        {
            LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), 0.15f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true);
        }
    }


}
