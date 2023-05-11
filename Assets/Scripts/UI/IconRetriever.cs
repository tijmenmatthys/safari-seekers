using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconRetriever : MonoBehaviour
{
    [SerializeField]
    private Sprite _mammal;
    [SerializeField]
    private Sprite _reptile;
    [SerializeField]
    private Sprite _invertebrate;
    [SerializeField]
    private Sprite _livesOnLand;
    [SerializeField]
    private Sprite _viviparous;
    [SerializeField]
    private Sprite _oviparous;
    [SerializeField]
    private Sprite _herbivore;
    [SerializeField]
    private Sprite _carnivore;
    [SerializeField]
    private Sprite _omnivore;
    [SerializeField]
    private Sprite _tail;
    [SerializeField]
    private Sprite _snout;
    [SerializeField]
    private Sprite _fur;
    [SerializeField]
    private Sprite _scales;
    [SerializeField]
    private Sprite _fourlegs;
    [SerializeField]
    private Sprite _twolegs;
    [SerializeField]
    private Sprite _arms;
    [SerializeField]
    private Sprite _grasslands;
    [SerializeField]
    private Sprite _forests;
    [SerializeField]
    private Sprite _mountains;
    [SerializeField]
    private Sprite _swamps;
    [SerializeField]
    private Sprite _oceans;


    public Sprite GetIcon(AnimalCriterium criterium)
    {
        switch (criterium)
        {
            case (AnimalCriterium.Mammal):
                return _mammal;
            case (AnimalCriterium.Reptile):
                return _reptile;
            case (AnimalCriterium.Invertebrate):
                return _invertebrate;
            case (AnimalCriterium.LivesOnLand):
                return _livesOnLand;
            case (AnimalCriterium.Viviparous):
                return _viviparous;
            case (AnimalCriterium.Oviparous):
                return _oviparous;
            case (AnimalCriterium.Herbivore):
                return _herbivore;
            case (AnimalCriterium.Carnivore):
                return _carnivore;
            case (AnimalCriterium.Omnivore):
                return _omnivore;
            case (AnimalCriterium.HasTail):
                return _tail;
            case (AnimalCriterium.HasSnout):
                return _snout;
            case (AnimalCriterium.HasFur):
                return _fur;
            case (AnimalCriterium.HasScales):
                return _scales;
            case (AnimalCriterium.FourLegs):
                return _fourlegs;
            case (AnimalCriterium.TwoLegs):
                return _twolegs;
            case (AnimalCriterium.HasArms):
                return _arms;
            case (AnimalCriterium.Grasslands):
                return _grasslands;
            case (AnimalCriterium.Forest):
                return _forests;
            case (AnimalCriterium.Mountains):
                return _mountains;
            case (AnimalCriterium.Swamp):
                return _swamps;
            case (AnimalCriterium.Ocean):
                return _oceans;
        }

        return _mammal;
    }
}
