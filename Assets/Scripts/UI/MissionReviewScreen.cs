using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MissionReviewScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _missionReviewBackground;
    [SerializeField]
    private GameObject _missionReviewScreen;
    [SerializeField] 
    private GameObject _missionReview;

    [SerializeField]
    private TMP_Text _animalNameText;
    [SerializeField]
    private ImageRetriever _imageRetriever;


    [SerializeField]
    private List<TMP_Text> _criteriaListTextboxes;
    [SerializeField]
    private List<TMP_Text> _nextCriteriaTextboxes;

    [SerializeField]
    private List<GameObject> _criteriaCheckmarks;
    [SerializeField]
    private List<GameObject> _criteriaXMarks;
    [SerializeField]
    private GameObject _overallCorrect;
    [SerializeField] 
    private GameObject _overallWrong;

    [SerializeField]
    private GameObject _notificationObject;
    [SerializeField]
    private GameObject _spawnLocation;

    [SerializeField]
    private List<GameObject> _currentimageGameObjects;
    [SerializeField]
    private List<Image> _currentImages;

    public UnityEvent OnCorrect;
    public UnityEvent OnWrong;
    public UnityEvent OnFinalCorrect;
    public UnityEvent OnFinalWrong;

    public UnityEvent OnShowNextCriteria;

    [SerializeField]
    private GameObject _nextCriteriaScreen;
    [SerializeField]
    private TMP_Text _nextCriteriaList;
    [SerializeField]
    private List<GameObject> _nextImageGameObjects;
    [SerializeField]
    private List<Image> _nextImages;

    [SerializeField]
    private float _timeUntilNextCriteriumCheck = 0.75f;

    [SerializeField]
    private float _timeUntilNextMissionFades = 2f;

    [SerializeField]
    private IconRetriever _iconRetriever;

    public UnityEvent OnFinishedNextCriteriaShowing;

    private List<bool> _resultValues = new List<bool>();
    private bool _finalResult, _isActive, _hasFinishedCheckingCriteria, _hasFinishedShowingFinalResult, _hasFinishedShowingNextCriteria;
    private int _currentCriteriaIndex;
    private float _counter;
    private CriteriaList _criteriaList;
    private PrefixAdder _prefixAdder;
    private Mission _nextMission;
    private GameLoop _gameLoop;
    private Timer _timer;

    private void Start()
    {
        _criteriaList = FindObjectOfType<CriteriaList>();
        _prefixAdder = new PrefixAdder();
        _gameLoop = FindObjectOfType<GameLoop>();
        _timer = FindObjectOfType<Timer>();
    }
    // Update is called once per frame
    void Update()
    {

        if (_counter > 0 && _isActive)
            _counter -= Time.unscaledDeltaTime;

        if (_counter <= 0 && _isActive)
        {
            if (!_hasFinishedCheckingCriteria)
                CheckNextCriteria();
            else if (!_hasFinishedShowingFinalResult)
                ShowFinalResult();
            else if (!_hasFinishedShowingNextCriteria)
                ShowNextCriteriaList();
            else
            {
                _gameLoop.TransitionToPlaying();

                if (_finalResult)
                    _timer.OnCorrectAnimalSelected();
                else
                    _timer.OnWrongAnimalSelected();

                _isActive = false;
                OnFinishedNextCriteriaShowing?.Invoke();
            }
                
        }
    }

    public void SetUpMissionReview(Dictionary<AnimalCriterium, bool> missionResults, Animal currentAnimal, bool missionSuccess, Mission nextMission)
    {
        _gameLoop.TransitionToPause();
        _isActive = true;
        ResetValues();
        _finalResult = missionSuccess;

        foreach (var kvp in missionResults)
            _resultValues.Add(kvp.Value);

        UpdateSelectedAnimalName(currentAnimal);
        UpdateSelectedAnimalPhoto(currentAnimal);
        UpdateCurrentCriteriaList(missionResults);
        UpdateNextCriteriaList(nextMission);
        _nextMission = nextMission;

        _missionReviewScreen.SetActive(true);
        _missionReview.SetActive(true);
        _missionReviewBackground.SetActive(true);
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

        _counter = _timeUntilNextCriteriumCheck + 0.5f;

        for (int i = 0; i < _criteriaCheckmarks.Count; i++)
        {
            _criteriaListTextboxes[i].text = "";
            _nextCriteriaTextboxes[i].text = "";
            _criteriaCheckmarks[i].SetActive(false);
            _criteriaXMarks[i].SetActive(false);
        }

        foreach (var go in _currentimageGameObjects)
            go.SetActive(false);
        foreach (var go in _nextImageGameObjects) 
            go.SetActive(false);

        _overallCorrect.SetActive(false);
        _overallWrong.SetActive(false);
    }

    private void UpdateSelectedAnimalName(Animal currentAnimal)
    {
        _animalNameText.text = $"Selected Animal: {currentAnimal.name}";
    }

    private void UpdateSelectedAnimalPhoto(Animal currentAnimal)
    {
       var image = _imageRetriever.GetImage(currentAnimal);
       image.SetActive(true);
    }

    private void UpdateCurrentCriteriaList(Dictionary<AnimalCriterium, bool> criterias)
    {
        int counter = 0;
        foreach (var criteria in criterias)
        {
            _criteriaListTextboxes[counter].text = $"-  {_prefixAdder.AddPrefixOrSpace(criteria.Key)}";
            _currentimageGameObjects[counter].SetActive(true);
            _currentImages[counter].sprite = _iconRetriever.GetIcon(criteria.Key);
            counter++;
        }
    }

    private void CheckNextCriteria()
    {
        if (_resultValues[_currentCriteriaIndex])
        {
            _criteriaCheckmarks[_currentCriteriaIndex].SetActive(true);
            OnCorrect?.Invoke();
        }
        else
        {
            _criteriaXMarks[_currentCriteriaIndex].SetActive(true);
            OnWrong?.Invoke();
        }

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
        {
            var obj = Instantiate(_notificationObject, _spawnLocation.transform);
            obj.GetComponent<TimePickupTweener>().SetUpNotification(_timer.CorrectAnimalRewardTime);
            _overallCorrect.SetActive(true);
            OnFinalCorrect?.Invoke();
        }
        else
        {
            var obj = Instantiate(_notificationObject, _spawnLocation.transform);
            obj.GetComponent<TimePickupTweener>().SetUpNotification(-_timer.WrongAnimalPenaltyTime);
            _overallWrong.SetActive(true);
            OnFinalWrong?.Invoke();
        }
        _counter = _timeUntilNextMissionFades + 1;
        _hasFinishedShowingFinalResult = true;

    }

    private void ShowNextCriteriaList()
    {
        OnShowNextCriteria?.Invoke();
        _nextCriteriaScreen.SetActive(true);
        _criteriaList.UpdateCriteriaList(_nextMission);
        _counter = _timeUntilNextMissionFades + 1.5f;
        _hasFinishedShowingNextCriteria = true;
    }


    private void UpdateNextCriteriaList(Mission nextCriteria)
    {
        int counter = 0;
        foreach (var criteria in nextCriteria.Criteria)
        {
            _nextCriteriaTextboxes[counter].text = $"-  {_prefixAdder.AddPrefixOrSpace(criteria)}";
            _nextImageGameObjects[counter].SetActive(true);
            _nextImages[counter].sprite = _iconRetriever.GetIcon(criteria);
            counter++;
        }
    }


}
