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
        if (Economy.instance.GetBalance(Material.MONEY) < DestroyCost())
        {
            Camera.main.transform.GetComponent<MessageService>()
                .SendMessage("Not enough money to demolish the building!");
            return false;
        }
            
        Economy.instance.PayMaterial(Material.MONEY, DestroyCost());
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
