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
    [SerializeField]
    private bool _rescaleOnDisable = false;
    [SerializeField]
    private bool _fadeInOnEnable = false;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    public LeanTweenType easeType;
    public UnityEvent OnTweenUpComplete;
    public UnityEvent OnTweenDownComplete;

    private void OnEnable()
    {
        if (_fadeInOnEnable)
            FadeObjectIn();
        else
            ScaleObjectUp();
    }

    private void OnDisable()
    {
        if (_rescaleOnDisable)
            this.gameObject.transform.localScale = Vector3.zero;
    }
    public void ScaleObjectUp()
    {
        LeanTween.scale(tweenObject, new Vector3(1f, 1f, 1f), _duration).setEase(easeType).setOnComplete(OnTweenUpDone).setIgnoreTimeScale(true);
    }

    public void ScaleObjectDown()
    {
        LeanTween.scale(tweenObject, new Vector3(0f, 0f, 0f), _duration).setEase(easeType).setOnComplete(OnTweenDownDone).setIgnoreTimeScale(true);
    }

    public void FadeObjectIn()
    {
        LeanTween.alphaCanvas(_canvasGroup, 1f, _duration).setEase(easeType).setIgnoreTimeScale(true);
    }

    public void FadeObjectOut()
    {
        LeanTween.alphaCanvas(_canvasGroup, 0f, _duration).setEase(easeType).setIgnoreTimeScale(true).setOnComplete(OnTweenDownDone);
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
