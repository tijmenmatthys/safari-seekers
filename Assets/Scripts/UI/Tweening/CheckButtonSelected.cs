using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CheckButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnButtonSelected;

    private void OnEnable()
    {
        this.gameObject.transform.localScale = Vector3.one;
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (eventData.selectedObject == this.gameObject)
        {
            TweenUp(this.gameObject);
            OnButtonSelected?.Invoke();
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (eventData.selectedObject == this.gameObject)
        {
            TweenDown(this.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject != EventSystem.current.currentSelectedGameObject)
            TweenDown(EventSystem.current.currentSelectedGameObject);

        TweenUp(this.gameObject);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(this.gameObject);
        OnButtonSelected?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TweenDown(this.gameObject); 
    }

    private void TweenUp(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.5f, 1.5f, 1.5f), 0.15f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true);
    }

    private void TweenDown(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1f, 1f, 1f), 0.15f).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true);
    }
}
