using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MissionReviewScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _missionReviewScreen;

    [SerializeField]
    private TMP_Text _animalNameText;
    [SerializeField]
    private TMP_Text _currentCriteriaListText;

    [SerializeField]
    private List<GameObject> _criteriaCheckmarks;
    [SerializeField]
    private List<GameObject> _criteriaXMarks;


    [SerializeField]
    private float _timeUntilNextCriteriumCheck;

    [SerializeField]
    private float _timeUntilNextMissionFades = 1f;

    private List<bool> _resultValues = new List<bool>();
    private bool _finalResult;
    private int _currentCriteriaIndex;


    // Update is called once per frame
    void Update()
    {
        while (_currentCriteriaIndex < _resultValues.Count)
            CheckNextCriteria();

        _timeUntilNextMissionFades -= Time.deltaTime;
        if (_timeUntilNextMissionFades <= 0 )
            _missionReviewScreen.SetActive(false);
    }

    public void SetUpMissionReview(Dictionary<AnimalCriterium, bool> missionResults, Animal currentAnimal, bool missionSuccess)
    {
        ResetValues();
        _finalResult = missionSuccess;

        foreach (var kvp in missionResults)
            _resultValues.Add(kvp.Value);

        UpdateSelectedAnimalName(currentAnimal);
        UpdateCurrentCriteriaList(missionResults);

        _missionReviewScreen.SetActive(true);
    }

    private void ResetValues()
    {
        _currentCriteriaIndex = 0;
        _resultValues.Clear();

        _timeUntilNextMissionFades = 1f;

        for (int i = 0; i < _criteriaCheckmarks.Count; i++)
        {
            _criteriaCheckmarks[i].SetActive(false);
            _criteriaXMarks[i].SetActive(false);
        }
    }

    private void UpdateSelectedAnimalName(Animal currentAnimal)
    {
        _animalNameText.text = $"Selected Animal: {currentAnimal.name}";
    }

    private void UpdateCurrentCriteriaList(Dictionary<AnimalCriterium, bool> criterias)
    {
        string criteriaList = "";
        foreach (var kvp in criterias)
            criteriaList += $"- {kvp.Key}\n";

        _currentCriteriaListText.text = criteriaList;
    }

    private void CheckNextCriteria()
    {
        if (_resultValues[_currentCriteriaIndex])
            _criteriaCheckmarks[_currentCriteriaIndex].SetActive(true);
        else
            _criteriaXMarks[_currentCriteriaIndex].SetActive(true);

        _currentCriteriaIndex++;
    }


}
