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
}
