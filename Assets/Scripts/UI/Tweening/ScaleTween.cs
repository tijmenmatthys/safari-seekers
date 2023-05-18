using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    public GameObject tweenObject;
    [SerializeField]
    private float _duration = 0.5f;
    public LeanTweenType easeType;
    public UnityEvent OnTweenUpComplete;
    public UnityEvent OnTweenDownComplete;

    private void OnEnable()
    {
        ScaleObjectUp();
    }
    public void ScaleObjectUp()
    {
        LeanTween.scale(tweenObject, new Vector3(1f, 1f, 1f), _duration).setEase(easeType).setOnComplete(OnTweenUpDone).setIgnoreTimeScale(true);
    }

    public void ScaleObjectDown()
    {
        LeanTween.scale(tweenObject, new Vector3(0f, 0f, 0f), _duration).setEase(easeType).setOnComplete(OnTweenDownDone).setIgnoreTimeScale(true);
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
