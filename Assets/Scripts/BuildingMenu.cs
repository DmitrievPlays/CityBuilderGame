using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingMenu : MonoBehaviour
{
    UIDocument menu;
    VisualTreeAsset menuItem;
    bool isOpen = false;


    Dictionary<BuildingCategory, BuildingType[]> buildingVariants = new Dictionary<BuildingCategory, BuildingType[]>
    {
        {BuildingCategory.Residential, new []{BuildingType.Residential}},
        {BuildingCategory.Commercial, new []{BuildingType.Supermarket, BuildingType.Hotel, BuildingType.Casino}},
        {BuildingCategory.Industrial, new []{BuildingType.PowerProduction, BuildingType.WaterProduction, BuildingType.Mine}},
        {BuildingCategory.Government, new []{BuildingType.Library}},
        {BuildingCategory.EmergencyService, new []{BuildingType.Medical, BuildingType.Police, BuildingType.Fire}}
    };

    void Start()
    {
        menu = GameObject.Find("BuildingMenu").GetComponent<UIDocument>();
        menuItem = Resources.Load<VisualTreeAsset>("UI Toolkit/MenuItem");
        menu.rootVisualElement.style.display = DisplayStyle.None;

        Events.instance.Subscribe("toggleMenu", () => ToggleMenu());
    }

    void ToggleMenu()
    {
        if (isOpen)
        {
            menu.rootVisualElement.style.display = DisplayStyle.None;
            menu.rootVisualElement.Q("menu").Clear();
            isOpen = !isOpen;
            Camera.main.GetComponent<BuildingProcess>().CancelBuilding();
            return;
        }
        else
        {
            GeneratePage(buildingVariants.Keys.ToArray());
            menu.rootVisualElement.style.display = DisplayStyle.Flex;
            isOpen = !isOpen;
        }
    }


    void GeneratePage<T>(T[] values)
    {
        menu.rootVisualElement.Q("menu").Clear();
        foreach (T value in values)
        {
            VisualElement root = menuItem.CloneTree();
            root.Q<Label>("label").text = value.ToString();

            switch (value)
            {
                case BuildingCategory cat:
                    Texture2D icon = Resources.Load<Texture2D>("Icons/" + cat.ToString().ToLower());
                    root.Q("icon").style.backgroundImage = new StyleBackground(icon);
                    root.Q<Button>("root").clicked += () => { GeneratePage(buildingVariants[cat]); };
                    break;
                case BuildingType type:
                    Action onClick = () => {
                        GameObject[] buildings = Resources.LoadAll<GameObject>("Prefabs/Buildings/" + type.ToString()); 
                        GeneratePage(buildings);
                    };
                    if (values.Length == 1)
                    {
                        onClick();
                        return;
                    }
                    root.Q<Button>("root").clicked += onClick;
                    break;
                case GameObject obj:
                    root.Q<Label>("label").text = obj.name.ToString();
                    root.Q<Button>("root").clicked += () => { Camera.main.GetComponent<BuildingProcess>().SetObjectToBuild(obj); };
                    break;
                default:
                    Debug.LogError("Invalid type");
                    break;
            }
            menu.rootVisualElement.Q("menu").Add(root);
        }
    }
}


enum BuildingType
{
    Residential,

    //Commercial
    Supermarket,
    Hotel,
    Casino,

    //Industrial
    PowerProduction,
    WaterProduction,
    Mine,

    //Government
    Library,

    //EmergencyService
    Medical,
    Police,
    Fire
}

enum BuildingCategory
{
    Residential,
    Commercial,
    Industrial,
    Government,
    EmergencyService,
}