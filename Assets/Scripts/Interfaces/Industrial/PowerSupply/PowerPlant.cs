using UnityEngine;

public class PowerPlant : MonoBehaviour, IStructure
{
    public string GetDescription()
    {
        return "Снабжает близлежащие строения города электричеством.";
    }

    public string GetName()
    {
        return "Электростанция";
    }

    public double GetPlacementCost()
    {
        return 170000;
    }

    public bool IsDestructible()
    {
        return true;
    }
}
