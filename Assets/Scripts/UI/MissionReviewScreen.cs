using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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
    private GameObject _overallCorrect;
    [SerializeField] 
    private GameObject _overallWrong;

    [SerializeField]
    private GameObject _nextCriteriaScreen;
    [SerializeField]
    private TMP_Text _nextCriteriaList;



    [SerializeField]
    private float _timeUntilNextCriteriumCheck = 1f;

    [SerializeField]
    private float _timeUntilNextMissionFades = 2f;

    private List<bool> _resultValues = new List<bool>();
    private bool _finalResult, _isActive, _hasFinishedCheckingCriteria, _hasFinishedShowingFinalResult, _hasFinishedShowingNextCriteria;
    private int _currentCriteriaIndex;
    private float _counter;
    private CriteriaList _criteriaList;
    private PrefixAdder _prefixAdder;
    private Mission _nextMission;

    private void Start()
    {
        _criteriaList = FindObjectOfType<CriteriaList>();
        _prefixAdder = new PrefixAdder();
    }
    // Update is called once per frame
    void Update()
    {
        /*
        while (_currentCriteriaIndex < _resultValues.Count)
            CheckNextCriteria();

        _timeUntilNextMissionFades -= Time.deltaTime;
        if (_timeUntilNextMissionFades <= 0 )
            _missionReviewScreen.SetActive(false);
        */

        if (_counter > 0 && _isActive)
            _counter -= Time.deltaTime;

        if (_counter <= 0 && _isActive)
        {
            if (!_hasFinishedCheckingCriteria)
                CheckNextCriteria();
            else if (!_hasFinishedShowingFinalResult)
                ShowFinalResult();
            else if (!_hasFinishedShowingNextCriteria)
                ShowNextCriteria();
            else
            {
                _isActive = false;
                _missionReviewScreen.SetActive(false);
            }
                
        }
    }

    public void SetUpMissionReview(Dictionary<AnimalCriterium, bool> missionResults, Animal currentAnimal, bool missionSuccess, Mission nextMission)
    {
        _isActive = true;
        ResetValues();
        _finalResult = missionSuccess;

        foreach (var kvp in missionResults)
            _resultValues.Add(kvp.Value);

        UpdateSelectedAnimalName(currentAnimal);
        UpdateCurrentCriteriaList(missionResults);
        UpdateNextCriteriaList(nextMission);
        _nextMission = nextMission;

        _missionReviewScreen.SetActive(true);
    }

    private void ResetValues()
    {
        _currentCriteriaIndex = 0;
        _nextCriteriaScreen.SetActive(false);
        _resultValues.Clear();

        _finalResult = false;
        _hasFinishedCheckingCriteria = false;
        _hasFinishedShowingFinalResult = false;
        _hasFinishedShowingNextCriteria = false;

        _counter = _timeUntilNextCriteriumCheck;

        for (int i = 0; i < _criteriaCheckmarks.Count; i++)
        {
            _criteriaCheckmarks[i].SetActive(false);
            _criteriaXMarks[i].SetActive(false);
        }

        _overallCorrect.SetActive(false);
        _overallWrong.SetActive(false);
    }

    private void UpdateSelectedAnimalName(Animal currentAnimal)
    {
        _animalNameText.text = $"Selected Animal: {currentAnimal.name}";
    }

    private void UpdateCurrentCriteriaList(Dictionary<AnimalCriterium, bool> criterias)
    {
        string criteriaList = "";
        foreach (var kvp in criterias)
            criteriaList += $"- {_prefixAdder.AddPrefixOrSpace(kvp.Key)}\n";

        _currentCriteriaListText.text = criteriaList;
    }

    private void UpdateNextCriteriaList(Mission nextCriteria)
    {
        string criteriaList = "";
        foreach (var Criteria in nextCriteria.Criteria)
            criteriaList += $"- {_prefixAdder.AddPrefixOrSpace(Criteria)}\n";

        _nextCriteriaList.text = criteriaList;
    }

    private void CheckNextCriteria()
    {
        if (_resultValues[_currentCriteriaIndex])
            _criteriaCheckmarks[_currentCriteriaIndex].SetActive(true);
        else
            _criteriaXMarks[_currentCriteriaIndex].SetActive(true);

        _currentCriteriaIndex++;

        if (_currentCriteriaIndex < _resultValues.Count)
            _counter = _timeUntilNextCriteriumCheck;
        else
        {
            _counter = _timeUntilNextMissionFades;
            _hasFinishedCheckingCriteria = true;
        }
    }

    private void ShowFinalResult()
    {
        if (_finalResult)
            _overallCorrect.SetActive(true);
        else
            _overallWrong.SetActive(true);

        _counter = _timeUntilNextMissionFades;
        _hasFinishedShowingFinalResult = true;

    }

    private void ShowNextCriteria()
    {
        _nextCriteriaScreen.SetActive(true);
        _criteriaList.UpdateCriteriaList(_nextMission);
        _counter = _timeUntilNextMissionFades;
        _hasFinishedShowingNextCriteria = true;
    }


}
