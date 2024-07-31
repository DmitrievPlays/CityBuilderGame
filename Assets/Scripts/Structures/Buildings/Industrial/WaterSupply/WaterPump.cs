using UnityEngine;

public class WaterPump : WaterProductor
{
    public override double DestroyCost()
    {
        return 90000;
    }

    public override bool Enter(int amount)
    {
        throw new System.NotImplementedException();
    }

    public override int GetCurrentOccupancy()
    {
        throw new System.NotImplementedException();
    }

    public override string GetDescription()
    {
        return "Снабжает близлежащие строения города водой.";
    }

    public override double GetGenerationRate()
    {
        return 5;
    }

    public override int GetMaxOccupancy()
    {
        throw new System.NotImplementedException();
    }

    public override string GetName()
    {
        return "Станция водозабора";
    }

    public override double GetPlacementCost()
    {
        return 240000;
    }

    public override double GetWaterDemand()
    {
        throw new System.NotImplementedException();
    }

    public bool IsDestructible()
    {
        return true;
    }

    public override bool Leave(int amount)
    {
        throw new System.NotImplementedException();
    }
}
