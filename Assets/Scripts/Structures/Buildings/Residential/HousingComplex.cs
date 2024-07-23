using UnityEngine;

public class HousingComplex : MonoBehaviour, IStructure, IWaterConsumer, IEnergyConsumer
{
    public string GetDescription()
    {
        return "Самые обсуждаемые по дурной славе постройки жилого комплекса от всеми известной компании ПИК";
    }

    public double GetEnergyDemand()
    {
        return 13;
    }

    public string GetName()
    {
        return "ЖК «ПИК»";
    }

    public double GetPlacementCost()
    {
        return 8000000;
    }

    public double GetWaterDemand()
    {
        return 34;
    }

    public bool IsDestructible()
    {
        return false;
    }
}
