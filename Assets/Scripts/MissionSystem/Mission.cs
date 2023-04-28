using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mission
{
    public List<AnimalCriterium> Criteria { get; }

    public List<AnimalType> CorrectAnimals
    {
        get
        {
            List<AnimalType> correct = new List<AnimalType>();
            foreach (var type in Enum.GetValues(typeof(AnimalType)).Cast<AnimalType>())
                if (IsSuccess(type)) correct.Add(type);
            return correct;
        }
    }

    public Mission(List<AnimalCriterium> criteria)
    {
        Criteria = criteria;
    }

    public bool IsSuccess(AnimalType type)
    {
        foreach (AnimalCriterium target in Criteria)
            if (!AnimalCriteria.Get(type).Contains(target))
                return false;
        return true;
    }

    public Dictionary<AnimalCriterium, bool> CriteriaSuccesses(AnimalType type)
    {
        var successes = new Dictionary<AnimalCriterium, bool>();
        foreach (AnimalCriterium target in Criteria)
            successes[target] = AnimalCriteria.Get(type).Contains(target);
        return successes;
    }

    public override string ToString()
    {
        return $"Mission with {Criteria.Count} criteria:\n{String.Join(", ", Criteria)}";
    }
}
