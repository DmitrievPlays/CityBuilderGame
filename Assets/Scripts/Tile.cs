using UnityEngine;

public class Tile : MonoBehaviour, ILightable
{
    private bool isLightOn = false;

    public bool GetLightStatus()
    {
        return isLightOn;
    }

    public void SetLightStatus(bool lightStatus)
    {
        isLightOn = lightStatus;
        gameObject.GetComponent<Light>().enabled = isLightOn;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
