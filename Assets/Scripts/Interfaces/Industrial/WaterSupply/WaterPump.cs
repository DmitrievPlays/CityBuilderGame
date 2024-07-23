using UnityEngine;

public class WaterPump : MonoBehaviour, IStructure
{
    public string GetDescription()
    {
        return "Снабжает близлежащие строения города водой.";
    }

    public string GetName()
    {
        return "Станция водозабора";
    }

    public double GetPlacementCost()
    {
        return 240000;
    }

    public bool IsDestructible()
    {
        return true;
    }
}
