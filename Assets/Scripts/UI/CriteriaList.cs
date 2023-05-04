using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CriteriaList : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _nextCriteriaList;

    [SerializeField]
    private List<TMP_Text> _criteriaList;

    private PrefixAdder _prefixAdder;

    private void Start()
    {
        _prefixAdder = new PrefixAdder();   
    }

    public void UpdateCriteriaList(Mission currentMission)
    {
        foreach (var text in _criteriaList)
            text.text = "";
        /*
        foreach (var Criteria in currentMission.Criteria)
            criteriaList += $"- {_prefixAdder.AddPrefixOrSpace(Criteria)}\n";

        _nextCriteriaList.text = criteriaList;
        */

        int counter = 0;
        foreach (var Criteria in currentMission.Criteria)
        {
            _criteriaList[counter].text = $"- {_prefixAdder.AddPrefixOrSpace(Criteria)}";
            counter++;
        }

    }
}
