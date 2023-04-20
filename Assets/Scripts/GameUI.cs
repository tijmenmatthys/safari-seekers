using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField]
    private float _startTime;

    [SerializeField]
    private TextMeshProUGUI _timeUI;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        UpdateTimeUI();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (_timer <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void UpdateTimeUI()
    {
        int seconds = (int)(_timer % 60);
        int minutes = (int)(_timer / 60);

        _timeUI.text = $"{minutes:00}:{seconds:00}";
    }
}
