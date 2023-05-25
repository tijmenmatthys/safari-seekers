using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event Action TimeUp;

    [SerializeField] TextMeshProUGUI _timeText;

    [SerializeField] float _startTime = 15;
    [SerializeField] float _wrongAnimalPenaltyTime = 5;
    [SerializeField] float _correctAnimalRewardTime = 30;
    [SerializeField] float _smallPickupRewardTime = 1;
    [SerializeField] float _middlePickupRewardTime = 3;
    [SerializeField] float _bigPickupRewardTime = 5;
    [SerializeField] float _timerLowTime = 30;

    public GameObject notificationObject;
    public GameObject spawnLocation;

    [SerializeField]
    private UnityEvent _timeGained;

    [SerializeField]
    private UnityEvent _timeLost;

    private float _timeRemainingSeconds;
    [NonSerialized]public float totalTime;

    public float WrongAnimalPenaltyTime => _wrongAnimalPenaltyTime;
    public float CorrectAnimalRewardTime => _correctAnimalRewardTime;

    Animator _timerAnimator;

    public float TimeRemainingSeconds
    {
        get => _timeRemainingSeconds;
        set
        {
            if (value <= 0) TimeUp?.Invoke();
            _timeRemainingSeconds = value;
            int m = (int)(value / 60);
            int s = (int)(value % 60);
            _timeText.text = $"{m:00}:{s:00}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _timerAnimator = _timeText.GetComponent<Animator>();
        UpdateAfterStatChange();
    }
    public void UpdateAfterStatChange()
    {
        TimeRemainingSeconds = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemainingSeconds -= Time.deltaTime;
        totalTime += Time.deltaTime;

        if(TimeRemainingSeconds < _timerLowTime)
        {
            _timerAnimator.SetBool("TimeLow", true);
        }
        else
        {
            _timerAnimator.SetBool("TimeLow", false);
        }

        if (_timerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "TimeGain")
        {
            _timerAnimator.ResetTrigger("TimeGained");
        }
        else if(_timerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "TimeLoss")
        {
            _timerAnimator.ResetTrigger("TimeLost");
        }
    }

    public void OnWrongAnimalSelected()
    {
        TimeRemainingSeconds -= _wrongAnimalPenaltyTime;
        _timeLost.Invoke();
        var obj = Instantiate(notificationObject, spawnLocation.transform);
        obj.GetComponent<TimePickupTweener>().SetUpNotification(-_wrongAnimalPenaltyTime);
    }

    public void OnCorrectAnimalSelected()
    {
        TimeRemainingSeconds += _correctAnimalRewardTime;
        _timeGained.Invoke();
        var obj = Instantiate(notificationObject, spawnLocation.transform);
        obj.GetComponent<TimePickupTweener>().SetUpNotification(_correctAnimalRewardTime);
    }

    public void OnPickupCollected(TimePickupType type)
    {
        var obj = Instantiate(notificationObject, spawnLocation.transform);
        if (type == TimePickupType.Small)
        {
            TimeRemainingSeconds += _smallPickupRewardTime;
            obj.GetComponent<TimePickupTweener>().SetUpNotification(_smallPickupRewardTime);
        }
        else if (type == TimePickupType.Middle)
        {
            TimeRemainingSeconds += _middlePickupRewardTime;
            obj.GetComponent<TimePickupTweener>().SetUpNotification(_middlePickupRewardTime);
        }
        else if (type == TimePickupType.Big)
        {
            TimeRemainingSeconds += _bigPickupRewardTime;
            obj.GetComponent<TimePickupTweener>().SetUpNotification(_bigPickupRewardTime);
        }
        _timeGained.Invoke();
    }
}
