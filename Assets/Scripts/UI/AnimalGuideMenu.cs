using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGuideMenu : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _animalGuides = new List<GameObject>();

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
}
