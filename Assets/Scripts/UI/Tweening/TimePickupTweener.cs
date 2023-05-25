using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimePickupTweener : MonoBehaviour
{
    [SerializeField]
    private Image _panel;
    [SerializeField]
    private Image _panel2;
    [SerializeField] 
    private Sprite _wrongPanel;
    [SerializeField]
    private TextMeshProUGUI _timeText;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private LeanTweenType _spawnType;
    [SerializeField]
    private float _timeToPopIn = 0.5f, _delay = 0.5f, _timeTillDissapears = 1.5f;

    public void SetUpNotification(float timeBonus)
    {
        if (timeBonus < 0)
        {
            _panel.sprite = _wrongPanel;
            _panel2.sprite = _wrongPanel;
            _timeText.text = $"{timeBonus}";
        } else
            _timeText.text = $"+{timeBonus}";
        SpawnIn();
    }

    private void SpawnIn()
    {
        LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), _timeToPopIn).setEase(_spawnType).setOnComplete(MoveUpAndDissapear).setIgnoreTimeScale(true);
    }

    private void MoveUpAndDissapear()
    {
        LeanTween.moveLocalY(this.gameObject, 50f, _timeTillDissapears).setDelay(_delay).setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(_canvasGroup, 0, _timeTillDissapears).setDelay(_delay).setIgnoreTimeScale(true).setDestroyOnComplete(true);
    }
}
