using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PrefixAdder : MonoBehaviour
{
    public string AddPrefixOrSpace(AnimalCriterium criterium)
    {
        switch (criterium)
        {
            case (AnimalCriterium.Mammal):
                return "is a MAMMAL";
            case (AnimalCriterium.Reptile):
                return "is a REPTILE";
            case (AnimalCriterium.Invertebrate):
                return "is an INVERTEBRATE";
            case (AnimalCriterium.LivesOnLand):
                return "LIVES ON LAND";
            case (AnimalCriterium.Viviparous):
                return "is VIVIPAROUS";
            case (AnimalCriterium.Oviparous):
                return "is OVIPAROUS";
            case (AnimalCriterium.Herbivore):
                return "is a HERBIVORE";
            case (AnimalCriterium.Carnivore):
                return "is a CARNIVORE";
            case (AnimalCriterium.Omnivore):
                return "is a OMNIVORE";
            case (AnimalCriterium.HasTail):
                return "has a TAIL";
            case (AnimalCriterium.HasSnout):
                return "has a SNOUT";
            case (AnimalCriterium.HasFur):
                return "has FUR";
            case (AnimalCriterium.HasScales):
                return "has SCALES";
            case (AnimalCriterium.FourLegs):
                return "has FOUR LEGS";
            case (AnimalCriterium.TwoLegs):
                return "has TWO LEGS";
            case (AnimalCriterium.HasArms):
                return "has ARMS";
            case (AnimalCriterium.Grasslands):
                return "lives in GRASSLANDS";
            case (AnimalCriterium.Forest):
                return "lives in FORESTS";
            case (AnimalCriterium.Mountains):
                return "lives in MOUNTAINS";
            case (AnimalCriterium.Swamp):
                return "lives in SWAMPS";
            case (AnimalCriterium.Ocean):
                return "lives in OCEANS";
        }

        return "Error: Criterium Not Found";
    }
}
