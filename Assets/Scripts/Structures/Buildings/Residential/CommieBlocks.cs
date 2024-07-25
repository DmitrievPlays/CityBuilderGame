using System;
using UnityEngine;

public class CommieBlocks : ResidentialBuilding
{
    public override double DestroyCost()
    {
        return 230000;
    }

    public override string GetDescription()
    {
        return "Древняя, но в то же время уютная из 100 квартир и 5 подъездов жилая постройка.";
    }

    public override double GetEnergyDemand()
    {
        return 3;
    }

    public override string GetName()
    {
        return "Хрущевка";
    }

    public override double GetPlacementCost()
    {
        return 1500000;
    }

    public override double GetWaterDemand()
    {
        return 8;
    }
}
