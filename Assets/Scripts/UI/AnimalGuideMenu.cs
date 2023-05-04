using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnimalGuideMenu : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _animalGuides = new List<GameObject>();

    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;

    private int _animalGuideIndex;


    private void Start()
    {
        UpdateGuidePage();
    }

    public void PageLeft()
    {
        _animalGuideIndex--;
        if ( _animalGuideIndex < 0 )
            _animalGuideIndex = _animalGuides.Count - 1;

        UpdateGuidePage();
    }

    public void PageRight()
    {
        _animalGuideIndex++;
        if (_animalGuideIndex > _animalGuides.Count - 1)
            _animalGuideIndex = 0;

        UpdateGuidePage();
    }

    private void UpdateGuidePage()
    {
        foreach (GameObject go in _animalGuides )
        {
            go.SetActive(false);
        }

        _animalGuides[_animalGuideIndex].SetActive(true);
    }

    private void OnRight(InputValue value)
    {
        _rightButton.onClick?.Invoke();
    }

    private void OnLeft(InputValue value)
    {
        _leftButton.onClick?.Invoke();
    }
}
