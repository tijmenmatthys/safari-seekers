using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct CriteriumCountDifficultyLevel
{
    public int AnimalsFound;
    public int MinCriteria;
    public int MaxCriteria;
}

[Serializable]
public struct CorrectAnimalsDifficultyLevel
{
    public int AnimalsFound;
    public int MinCorrectAnimals;
    public int MaxCorrectAnimals;
}

public class MissionGenerator : MonoBehaviour
{
    [SerializeField] private List<CriteriumCountDifficultyLevel> _criteriumCountDifficulties;
    [SerializeField] private List<CorrectAnimalsDifficultyLevel> _correctAnimalsDifficulties;
    [SerializeField] private int _retryAttempts = 10;

    private int _minCriteria;
    private int _maxCriteria;
    private int _minCorrectAnimals;
    private int _maxCorrectAnimals;

    private void OnValidate()
    {
        // inverse order sorting based on AnimalsFound, to be uses later to calculate difficulties
        _criteriumCountDifficulties.Sort((a, b) => - a.AnimalsFound.CompareTo(b.AnimalsFound));
        _correctAnimalsDifficulties.Sort((a, b) => - a.AnimalsFound.CompareTo(b.AnimalsFound));
    }

    public void UpdateDifficulty(int animalsFound)
    {
        foreach (var difficultyLevel in  _criteriumCountDifficulties)
        {
            if (animalsFound >= difficultyLevel.AnimalsFound)
            {
                _minCriteria = difficultyLevel.MinCriteria;
                _maxCriteria = difficultyLevel.MaxCriteria;
                break;
            }
        }
        foreach (var difficultyLevel in _correctAnimalsDifficulties)
        {
            if (animalsFound >= difficultyLevel.AnimalsFound)
            {
                _minCorrectAnimals = difficultyLevel.MinCorrectAnimals;
                _maxCorrectAnimals = difficultyLevel.MaxCorrectAnimals;
                break;
            }
        }
        Debug.Log($"Difficulty level updated using {animalsFound} animals already found.");
        Debug.Log($"Mission Criteria Count will be within ({_minCriteria}, {_maxCriteria})");
        Debug.Log($"Mission Correct Animal Count will be within ({_minCorrectAnimals}, {_maxCorrectAnimals})");
    }

    public Mission Generate()
    {
        int criteriumCount = Random.Range(_minCriteria, _maxCriteria + 1);
        while (true)
        {
            for (int i = 0; i < _retryAttempts; i++)
            {
                var missionCriteria = GenerateCriteria(criteriumCount);
                Mission mission = new Mission(missionCriteria);
                var correctAnimals = mission.CorrectAnimals;
                if (_minCorrectAnimals <= correctAnimals.Count && correctAnimals.Count <= _maxCorrectAnimals)
                {
                    Debug.Log($"Mission succesfully generated after {i} retries.");
                    Debug.Log(mission);
                    Debug.Log($"This mission can be completed with the following {correctAnimals.Count} animals:\n{String.Join(", ",correctAnimals)}");
                    return mission;
                }
            }
            Debug.LogWarning($"Mission generation failed after {_retryAttempts} attempts with {criteriumCount} criteria.");
            criteriumCount--;
            Debug.LogWarning($"Mission generation will retry with only {criteriumCount} criteria.");
        }
    }

    private List<AnimalCriterium> GenerateCriteria(int criteriumCount)
    {
        var possibleCriteria = Enum.GetValues(typeof(AnimalCriterium))
                    .Cast<AnimalCriterium>().ToHashSet();
        var missionCriteria = new List<AnimalCriterium>();
        while (missionCriteria.Count < criteriumCount)
        {
            // check if we still have enough possible criteria left to generate the next
            if (possibleCriteria.Count == 0)
            {
                Debug.LogWarning($"There are not enough criteria available to generate {criteriumCount} mutually exclusive ones");
                break;
            }

            // generate next criterium
            var newCriterium = possibleCriteria.ElementAt(Random.Range(0, possibleCriteria.Count));
            missionCriteria.Add(newCriterium);
            possibleCriteria.Remove(newCriterium);

            // remove other mutually exclusive criteria from the possibilities
            foreach (var group in AnimalCriteria.GetMutuallyExclusive())
                if (group.Contains(newCriterium))
                    possibleCriteria = possibleCriteria.Except(group).ToHashSet();
        }
        return missionCriteria;
    }
}
