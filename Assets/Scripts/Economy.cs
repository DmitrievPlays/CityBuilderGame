using UnityEngine;
using UnityEngine.UIElements;


public enum Material
{
    MONEY,
    GOLD,
    ENERGY,
    WATER,
    BRICK,
    CONCRETE
}


public class Economy : MonoBehaviour
{
    public static Economy instance = null;
    public static double money = 10000000;
    private double gold = 50;
    private double water = 3;
    private double energy = 4;
    private double brick = 15;
    private double concrete = 10;
    private UIDocument topbar;
    static AudioClip clipPay;


    void Start()
    {
        clipPay = (AudioClip)Resources.Load("Sounds/pay");

        topbar = GameObject.Find("TopBar").GetComponent<UIDocument>();

        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        Label l = topbar.rootVisualElement.Q("money") as Label;
        l.text = money.ToString();

        Label l2 = topbar.rootVisualElement.Q("gold") as Label;
        l2.text = gold.ToString();
    }

    public void PayMaterial(Material material, double amount)
    {
        switch(material)
        {
            case Material.MONEY: money -= amount; break;
            case Material.GOLD: gold -= amount; break;
            case Material.ENERGY: energy -= amount; break;
            case Material.WATER: water -= amount; break;
            case Material.BRICK: brick -= amount; break;
            case Material.CONCRETE: concrete -= amount; break;
        }
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clipPay);
        //MUST BE REPLACED WITH AUDIO SYSTEM SOON
    }

    public void GainMaterial(Material material, double amount)
    {
        switch (material)
        {
            case Material.MONEY: money += amount; break;
            case Material.GOLD: gold += amount; break;
            case Material.ENERGY: energy += amount; break;
            case Material.WATER: water += amount; break;
            case Material.BRICK: brick += amount; break;
            case Material.CONCRETE: concrete += amount; break;
        }
    }

    public double GetBalance(Material material)
    {
        switch (material)
        {
            case Material.MONEY: return money;
            case Material.GOLD: return gold;
            case Material.ENERGY: return energy;
            case Material.WATER: return water;
            case Material.BRICK: return brick;
            case Material.CONCRETE: return concrete;
            default: return 0;
        }
    }
}
