using System.Collections.Generic;
using UnityEngine;

public class BuildingsLightSwitcher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<ILightable> lightings = new List<ILightable>();

    public void ToggleLights()
    {
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>(sortMode: FindObjectsSortMode.None);
        for (int i = 0; i < allScripts.Length; i++)
        {
            if (allScripts[i] is ILightable)
                lightings.Add(allScripts[i] as ILightable);
        }

        for (int i = 0; i < lightings.Count; i++)
        {
            lightings[i].SetLightStatus(!lightings[i].GetLightStatus());
        }
    }
}
