using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    public GameObject tweenObject;
    public LeanTweenType easeType;
    public UnityEvent OnTweenUpComplete;
    public UnityEvent OnTweenDownComplete;

    private void OnEnable()
    {
        ScaleObjectUp();
    }
    public void ScaleObjectUp()
    {
        LeanTween.scale(tweenObject, new Vector3(1f, 1f, 1f), 0.5f).setEase(easeType).setOnComplete(OnTweenUpDone);
    }

    public void ScaleObjectDown()
    {
        LeanTween.scale(tweenObject, new Vector3(0f, 0f, 0f), 0.5f).setEase(easeType).setOnComplete(OnTweenDownDone);
    }

    private void OnTweenUpDone()
    {
        OnTweenUpComplete?.Invoke();
    }

    private void OnTweenDownDone()
    {
        OnTweenDownComplete?.Invoke();
    }
}
