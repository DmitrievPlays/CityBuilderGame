using UnityEngine;

public class HousingComplex : ResidentialBuilding
{
    public override string GetDescription()
    {
        return "Самые обсуждаемые по дурной славе постройки жилого комплекса от всеми известной компании ПИК";
    }

    public override double GetEnergyDemand()
    {
        return 13;
    }

    public override string GetName()
    {
        return "ЖК «ПИК»";
    }

    public override double GetPlacementCost()
    {
        return 8000000;
    }

    public override double GetWaterDemand()
    {
        return 34;
    }


    public override bool Destroy()
    {
        Camera.main.transform.GetComponent<MessageService>().SendMessage("No!");
        return false;
    }

    public override double DestroyCost()
    {
        return 500000;
    }

    public override int GetMaxOccupancy()
    {
        throw new System.NotImplementedException();
    }

    public override int GetCurrentOccupancy()
    {
        throw new System.NotImplementedException();
    }

    public override bool Leave(int amount)
    {
        throw new System.NotImplementedException();
    }

    public override bool Enter(int amount)
    {
        throw new System.NotImplementedException();
    }
}
