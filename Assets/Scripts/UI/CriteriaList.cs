using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CriteriaList : MonoBehaviour
{
    [SerializeField]
    private List<TMP_Text> _criteriaList;

    [SerializeField]
    private List<GameObject> _imageGameObjects;

    [SerializeField]
    private List<Image> _images;

    [SerializeField]
    private IconRetriever _iconRetriever;

    private PrefixAdder _prefixAdder = new PrefixAdder();

    public void UpdateCriteriaList(Mission currentMission)
    {
        foreach (var text in _criteriaList)
            text.text = "";
        foreach (var go in _imageGameObjects)
            go.SetActive(false);

        int counter = 0;
        foreach (var Criteria in currentMission.Criteria)
        {
            _criteriaList[counter].text = $"{_prefixAdder.AddPrefixOrSpace(Criteria)}";
            _imageGameObjects[counter].SetActive(true);
            _images[counter].sprite = _iconRetriever.GetIcon(Criteria);
            counter++;
        }

    }
}
