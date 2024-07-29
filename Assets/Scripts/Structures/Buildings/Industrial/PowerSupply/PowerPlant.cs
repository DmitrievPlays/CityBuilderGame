public class PowerPlant : PowerProductor
{
    public override double DestroyCost()
    {
        return 120000;
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
        return "Снабжает близлежащие строения города электричеством.";
    }

    public override double GetGenerationRate()
    {
        return 9;
    }

    public override int GetMaxOccupancy()
    {
        throw new System.NotImplementedException();
    }

    public override string GetName()
    {
        return "Электростанция";
    }

    public override double GetPlacementCost()
    {
        return 170000;
    }

    public override double GetWaterDemand()
    {
        return 0;
    }

    public override bool Leave(int amount)
    {
        throw new System.NotImplementedException();
    }
}
