using System;
using UnityEngine;

public class CommieBlocks : MonoBehaviour, IStructure, IWaterConsumer, IEnergyConsumer, ILightable
{
    public string GetDescription()
    {
        return "Древняя, но в то же время уютная из 100 квартир и 5 подъездов жилая постройка.";
    }

    public double GetEnergyDemand()
    {
        return 3;
    }

    public bool GetLightStatus()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return "Хрущевка";
    }

    public double GetPlacementCost()
    {
        return 1500000;
    }

    public double GetWaterDemand()
    {
        return 8;
    }

    public bool IsDestructible()
    {
        return false;
    }

    public void SetLightStatus(bool lightStatus)
    {
        throw new NotImplementedException();
    }
}
