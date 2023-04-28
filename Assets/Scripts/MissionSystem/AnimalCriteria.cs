
using System;
using System.Collections.Generic;

public static class AnimalCriteria
{
    private static Dictionary<AnimalType, List<AnimalCriterium>> _criteria
        = new Dictionary<AnimalType, List<AnimalCriterium>>();

    static AnimalCriteria()
    {
        InitCriteria();
    }

    public static List<AnimalCriterium> Get(AnimalType type)
        => _criteria[type];


    private static void InitCriteria()
    {
        _criteria.Add(AnimalType.Rabbit, new List<AnimalCriterium>() {
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
        _criteria.Add(AnimalType.Dolphin, new List<AnimalCriterium>()
        {
            AnimalCriterium.Mammal,
            AnimalCriterium.Viviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasSnout,
            AnimalCriterium.Ocean
        });
        _criteria.Add(AnimalType.Crocodile, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Giraffe, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Goat, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Eagle, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Fish, new List<AnimalCriterium>()
        {
            AnimalCriterium.Oviparous,
            AnimalCriterium.HasTail,
            AnimalCriterium.Omnivore,
            AnimalCriterium.HasScales,
            AnimalCriterium.Swamp,
            AnimalCriterium.Ocean
        });
        _criteria.Add(AnimalType.Chimpanzee, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Octopus, new List<AnimalCriterium>()
        {
            AnimalCriterium.Oviparous,
            AnimalCriterium.Carnivore,
            AnimalCriterium.HasArms,
            AnimalCriterium.Invertebrate,
            AnimalCriterium.Ocean
        });
        _criteria.Add(AnimalType.Tiger, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Parrot, new List<AnimalCriterium>()
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
        _criteria.Add(AnimalType.Snake, new List<AnimalCriterium>()
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