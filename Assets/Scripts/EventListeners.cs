using System;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Events instance = null;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();


    void Start()
    {
        Subscribe("removeInfo", BuildingInfo.RemoveInfo);


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

    public void Subscribe(string eventName, Action listener)
    {
        if (!actions.ContainsKey(eventName))
        {
            actions[eventName] = null;
        }

        actions[eventName] += listener;
    }

    public void Unsubscribe(string eventName, Action listener)
    {
        if (actions.ContainsKey(eventName))
        {
            actions[eventName] -= listener;
        }
    }

    public void TriggerEvent(string eventName)
    {
        if (!actions.ContainsKey(eventName))
        {
            Debug.LogError($"Event with name {eventName} doesn't exist.");
            return;
        }
        actions[eventName]?.Invoke();
    }
}
