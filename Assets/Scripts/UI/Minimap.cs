using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [Header("References")]
    public RectTransform _minimapPoint1;
    public RectTransform _minimapPoint2;
    public Transform _worldPoint1;
    public Transform _worldPoint2;

    [Header("Player")]
    public RectTransform _playerMinimap;
    public Transform _playerWorld;

    private float _minimapRatio;

    private void Awake()
    {
        CalculateMapRatio();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMinimap.anchoredPosition = _minimapPoint1.anchoredPosition + 
            new Vector2((_playerWorld.position.x - _worldPoint1.position.x) * _minimapRatio, 
            (_playerWorld.position.z - _worldPoint1.position.z) * _minimapRatio);
        _playerMinimap.eulerAngles = new Vector3(0, 0, -_playerWorld.rotation.eulerAngles.y);
    }

    public void CalculateMapRatio()
    {
        //distance world ignoring Y axis
        Vector3 distanceWorldVector = _worldPoint1.position - _worldPoint2.position;
        distanceWorldVector.y = 0;
        float distanceWorld = distanceWorldVector.magnitude;

        //distance minimap
        float distanceMinimap = Mathf.Sqrt(
            Mathf.Pow((_minimapPoint1.anchoredPosition.x - _minimapPoint2.anchoredPosition.x), 2) +
            Mathf.Pow((_minimapPoint1.anchoredPosition.y - _minimapPoint2.anchoredPosition.y), 2));

        _minimapRatio = distanceMinimap / distanceWorld;
    }
}
