using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private float _timeRemainingSeconds;
    public float totalTime;

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
        TimeRemainingSeconds = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemainingSeconds -= Time.deltaTime;
        totalTime += Time.deltaTime;
    }

    public void OnWrongAnimalSelected()
    {
        TimeRemainingSeconds -= _wrongAnimalPenaltyTime;
    }

    public void OnCorrectAnimalSelected()
    {
        TimeRemainingSeconds += _correctAnimalRewardTime;
    }

    public void OnPickupCollected(TimePickupType type)
    {
        if (type == TimePickupType.Small) TimeRemainingSeconds += _smallPickupRewardTime;
        else if (type == TimePickupType.Middle) TimeRemainingSeconds += _middlePickupRewardTime;
        else if (type == TimePickupType.Big) TimeRemainingSeconds += _bigPickupRewardTime;
    }
}
