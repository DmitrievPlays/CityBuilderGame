using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class Economy : MonoBehaviour
{
    public static Economy instance = null;
    private double money = 1000000000;
    private double gold = 100;
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

    public void PayMoney(double amount)
    {
        money -= amount;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clipPay);
    }

    public void GainMoney(double amount)
    {
        money += amount;
    }

    public void PayGold(double amount)
    {
        gold -= amount;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clipPay);
    }

    public void GainGold(double amount)
    {
        gold += amount;
    }

    public double GetMoneyBalance()
    {
        return money;
    }

    public double GetGoldBalance()
    {
        return gold;
    }
}
