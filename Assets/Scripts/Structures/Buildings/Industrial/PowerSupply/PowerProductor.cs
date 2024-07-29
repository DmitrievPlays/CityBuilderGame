using UnityEngine;

public abstract class PowerProductor : MonoBehaviour, IStructure, IWaterConsumer, IDestructible, IOccupancy, IEnergyProducer
{
    public abstract string GetDescription();
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
    public abstract double GetGenerationRate();
}
