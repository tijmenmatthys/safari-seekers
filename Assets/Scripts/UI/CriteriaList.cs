using TMPro;
using UnityEngine;

public class CriteriaList : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _nextCriteriaList;

    private PrefixAdder _prefixAdder;

    private void Start()
    {
        _prefixAdder = new PrefixAdder();   
    }

    public void UpdateCriteriaList(Mission currentMission)
    {
        string criteriaList = "An Animal that...:\n";
        foreach (var Criteria in currentMission.Criteria)
            criteriaList += $"- {_prefixAdder.AddPrefixOrSpace(Criteria)}\n";

        _nextCriteriaList.text = criteriaList;
    }
}
