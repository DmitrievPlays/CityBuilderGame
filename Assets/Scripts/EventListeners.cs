using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Events : MonoBehaviour
{
    public static Events instance = null;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    UIDocument topBar;


    void Start()
    {
        topBar = GameObject.Find("TopBar").GetComponent<UIDocument>();
        topBar.rootVisualElement.Q<Button>("pause").clicked += () => { Time.timeScale = 0; };
        topBar.rootVisualElement.Q<Button>("x1").clicked += () => { Time.timeScale = 1; };
        topBar.rootVisualElement.Q<Button>("x2").clicked += () => { Time.timeScale = 2; };
        topBar.rootVisualElement.Q<Button>("x3").clicked += () => { Time.timeScale = 3; };

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
        Debug.Log(eventName);
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
            Debug.LogWarning($"Event with name {eventName} doesn't exist.");
            return;
        }
        actions[eventName]?.Invoke();
    }
}
