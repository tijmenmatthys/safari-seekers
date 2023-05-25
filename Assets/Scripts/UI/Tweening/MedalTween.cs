using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalTween : MonoBehaviour
{
    public GameObject tweenObject;
    public LeanTweenType easeType;
    public void PingPong()
    {
        LeanTween.scale(tweenObject, new Vector3(1.25f, 1.25f, 1.25f), 3f).setLoopPingPong().setIgnoreTimeScale(true).setEase(easeType);
    }

    public void Rotate()
    {
        LeanTween.rotateAround(tweenObject, Vector3.forward, -360, 10f).setLoopClamp().setIgnoreTimeScale(true);
    }
}
