using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageRetriever : MonoBehaviour
{
    [SerializeField]
    private Sprite _chimpanzee;
    [SerializeField]
    private Sprite _crocodile;
    [SerializeField]
    private Sprite _dolphin;
    [SerializeField]
    private Sprite _eagle;
    [SerializeField]
    private Sprite _fish;
    [SerializeField]
    private Sprite _giraffe;
    [SerializeField]
    private Sprite _goat;
    [SerializeField]
    private Sprite _octopus;
    [SerializeField]
    private Sprite _parrot;
    [SerializeField]
    private Sprite _rabbit;
    [SerializeField]
    private Sprite _snake;
    [SerializeField]
    private Sprite _tiger;

    public Sprite GetImage(Animal animal)
    {
        switch (animal.AnimalType)
        {
            case AnimalType.Chimpanzee:
                return _chimpanzee;
            case AnimalType.Crocodile: 
                return _crocodile;
            case AnimalType.Dolphin: 
                return _dolphin;
            case AnimalType.Eagle: 
                return _eagle;
            case AnimalType.Fish:
                return _fish;
            case AnimalType.Giraffe:
                return _giraffe;
            case AnimalType.Goat: 
                return _goat;
            case AnimalType.Parrot:
                return _parrot;
            case AnimalType.Octopus:
                return _octopus;
            case AnimalType.Rabbit:
                return _rabbit;
            case AnimalType.Snake:
                return _snake;
            case AnimalType.Tiger:
                return _tiger;
        }

        return _chimpanzee;
    }

}
