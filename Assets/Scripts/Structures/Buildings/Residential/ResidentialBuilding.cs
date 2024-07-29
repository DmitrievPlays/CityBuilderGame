using UnityEngine;

public abstract class ResidentialBuilding : MonoBehaviour, IStructure, IWaterConsumer, IEnergyConsumer, IDestructible, IOccupancy
{
    public abstract string GetDescription();
    public abstract double GetEnergyDemand();
    public abstract string GetName();
    public abstract double GetPlacementCost();
    public abstract double GetWaterDemand();

    public virtual bool Destroy()
    {
        Economy.instance.PayMoney(DestroyCost());
        Object.Destroy((this as MonoBehaviour)?.gameObject);
        Events.instance.TriggerEvent("removeInfo");
        return true;
    }

    public abstract double DestroyCost();
    public abstract int GetMaxOccupancy();
    public abstract int GetCurrentOccupancy();
    public abstract bool Leave(int amount);
    public abstract bool Enter(int amount);
}
