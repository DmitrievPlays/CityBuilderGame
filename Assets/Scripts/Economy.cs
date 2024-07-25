using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class Economy : MonoBehaviour
{
    public static Economy instance = null;
    private double money = 1000000000;
    private UIDocument topbar;


    void Start()
    {

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
    }

    public void PayMoney(double amount)
    {
        money -= amount;
    }

    public void GainMoney(double amount)
    {
        money += amount;
    }

    public double GetBalance()
    {
        return money;
    }
}
