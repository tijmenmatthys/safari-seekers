using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMoveTween : MonoBehaviour
{

    [SerializeField]
    private float _OnScreenPosX;
    [SerializeField] 
    private float _OffScreenPosX;
    [SerializeField]
    private GameObject _instructionsPopUp;
    [SerializeField]
    private LeanTweenType _easeType;

    public void MovePanelOnScreen()
    {
        LeanTween.moveLocalX(_instructionsPopUp, _OnScreenPosX, 0.2f).setEase(_easeType).setIgnoreTimeScale(true);
    }

    public void MovePanelOffScreen()
    {
        LeanTween.moveLocalX(_instructionsPopUp, _OffScreenPosX, 0.2f).setEase(_easeType).setIgnoreTimeScale(true);
    }
}
