using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageRetriever : MonoBehaviour
{
    [SerializeField]
    private GameObject _chimpanzee;
    [SerializeField]
    private GameObject _crocodile;
    [SerializeField]
    private GameObject _dolphin;
    [SerializeField]
    private GameObject _eagle;
    [SerializeField]
    private GameObject _fish;
    [SerializeField]
    private GameObject _giraffe;
    [SerializeField]
    private GameObject _goat;
    [SerializeField]
    private GameObject _octopus;
    [SerializeField]
    private GameObject _parrot;
    [SerializeField]
    private GameObject _rabbit;
    [SerializeField]
    private GameObject _snake;
    [SerializeField]
    private GameObject _tiger;

    private List<GameObject> _images = new List<GameObject>();
    private void Awake()
    {
        _images.Add(_chimpanzee);
        _images.Add(_crocodile);
        _images.Add(_dolphin);
        _images.Add(_eagle);
        _images.Add(_fish);
        _images.Add(_giraffe);
        _images.Add(_goat);
        _images.Add(_octopus);
        _images.Add(_parrot);
        _images.Add(_rabbit);
        _images.Add(_snake);
        _images.Add(_tiger);
    }

    public GameObject GetImage(Animal animal)
    {
        foreach (GameObject image in _images)
        {
            image.SetActive(false);
        }

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
