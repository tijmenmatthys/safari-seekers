using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mission
{
    public List<AnimalCriterium> Criteria { get; }
        = new List<AnimalCriterium>();

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
        string output = $"Mission with {Criteria.Count} criteria:";
        foreach (AnimalCriterium target in Criteria)
            output += "\n" + target.ToString();
        return output;
    }
}
