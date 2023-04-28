
using System;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public static class AnimalCriteria
{
    private static Dictionary<AnimalType, List<AnimalCriterium>> _animalCriteria
        = new Dictionary<AnimalType, List<AnimalCriterium>>();

    private static List<List<AnimalCriterium>> _mutuallyExclusiveCriteria
        = new List<List<AnimalCriterium>>();

    static AnimalCriteria()
    {
        InitAnimalCriteria();
        InitMutuallyExclusiveCriteria();
    }

    public static List<AnimalCriterium> Get(AnimalType type)
        => _animalCriteria[type];

    public static List<List<AnimalCriterium>> GetMutuallyExclusive()
        => _mutuallyExclusiveCriteria;

    private static void InitMutuallyExclusiveCriteria()
    {
        _mutuallyExclusiveCriteria.Add(new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Reptile,
            AnimalCriterium.Invertebrate,
        });
        _mutuallyExclusiveCriteria.Add(new List<AnimalCriterium>()
        {
            AnimalCriterium.Viviparous,
            AnimalCriterium.Oviparous
        });
        _mutuallyExclusiveCriteria.Add(new List<AnimalCriterium>()
        {
            AnimalCriterium.Herbivore,
            AnimalCriterium.Carnivore,
            AnimalCriterium.Omnivore,
        });
        _mutuallyExclusiveCriteria.Add(new List<AnimalCriterium>()
        {
            AnimalCriterium.FourLegs,
            AnimalCriterium.TwoLegs
        });
        _mutuallyExclusiveCriteria.Add(new List<AnimalCriterium>()
        {
            AnimalCriterium.Grasslands,
            AnimalCriterium.Forest,
            AnimalCriterium.Mountains,
            AnimalCriterium.Swamp,
            AnimalCriterium.Ocean
        });
    }

    private static void InitAnimalCriteria()
    {
        _animalCriteria.Add(AnimalType.Rabbit, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Herbivore,
            AnimalCriterium.FourLegs,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.Grasslands,
            AnimalCriterium.Forest
        });
        _animalCriteria.Add(AnimalType.Dolphin, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasSnout,
            AnimalCriterium.Ocean
        });
        _animalCriteria.Add(AnimalType.Crocodile, new List<AnimalCriterium>()
        {
            AnimalCriterium.Reptile,
            AnimalCriterium.FourLegs,
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasSnout,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasScales,
            AnimalCriterium.Swamp
        });
        _animalCriteria.Add(AnimalType.Giraffe, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Herbivore,
            AnimalCriterium.FourLegs,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.Grasslands
        });
        _animalCriteria.Add(AnimalType.Goat, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Herbivore,
            AnimalCriterium.FourLegs,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.Mountains
        });
        _animalCriteria.Add(AnimalType.Eagle, new List<AnimalCriterium>()
        {
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasSnout,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.TwoLegs,
            AnimalCriterium.Forest,
            AnimalCriterium.Mountains
        });
        _animalCriteria.Add(AnimalType.Fish, new List<AnimalCriterium>()
        {
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Omnivore,
            AnimalCriterium.HasScales,
            AnimalCriterium.Swamp,
            AnimalCriterium.Ocean
        });
        _animalCriteria.Add(AnimalType.Chimpanzee, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.Omnivore,
            AnimalCriterium.TwoLegs,
            AnimalCriterium.HasArms,
            AnimalCriterium.Forest,
        });
        _animalCriteria.Add(AnimalType.Octopus, new List<AnimalCriterium>()
        {
            AnimalCriterium.Oviparous,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasArms,
            AnimalCriterium.Invertebrate,
            AnimalCriterium.Ocean
        });
        _animalCriteria.Add(AnimalType.Tiger, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.FourLegs,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasFur,
            AnimalCriterium.Grasslands,
            AnimalCriterium.Forest
        });
        _animalCriteria.Add(AnimalType.Parrot, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Herbivore,
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.HasSnout,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.TwoLegs,
            AnimalCriterium.Forest,
        });
        _animalCriteria.Add(AnimalType.Snake, new List<AnimalCriterium>()
        {
            AnimalCriterium.Reptile,
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.LivesOnLand,
            AnimalCriterium.HasScales,
            AnimalCriterium.Grasslands,
            AnimalCriterium.Forest,
            AnimalCriterium.Swamp
        });
    }
}