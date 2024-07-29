using UnityEngine;
using UnityEngine.UIElements;

public static class BuildingInfo
{
    private static GameObject template = Resources.Load<GameObject>("Prefabs/BuildingInfo");
    private static UIDocument UI;
    static AudioClip clipOpen = (AudioClip)Resources.Load("Sounds/bubble_open");

    //static AudioClip clipClose = (AudioClip)Resources.Load("Sounds/bubble_close");
    /// <summary>
    /// Show a popup with properties of the selected building.
    /// </summary>

    public static void ShowInfo<T>(T obj, GameObject canvas)
    {
        if(UI != null)
            GameObject.Destroy(canvas.transform.Find(UI.name)?.gameObject);
            

        if (obj as IStructure == null) return;

        UI = ResetInfo(obj, canvas).GetComponent<UIDocument>();
        

        Camera.main.GetComponent<AudioSource>().PlayOneShot(clipOpen);

        SetText(UI, "name", (obj as IStructure)?.GetName());
        SetText(UI, "descr", (obj as IStructure)?.GetDescription());
        SetText(UI, "water", (obj as IWaterConsumer)?.GetWaterDemand().ToString());
        SetText(UI, "energy", (obj as IEnergyConsumer)?.GetEnergyDemand().ToString());

        UI.transform.SetParent(canvas.transform, false);
        UI.rootVisualElement.Q("destroy").RegisterCallback<ClickEvent>((e) => {
            var a = (obj as IDestructible)?.Destroy();
            if (a != true)
            {
                Camera.main.transform.GetComponent<MessageService>()
                .SendMessage("You can't demolish this building!");
            }
        });
    }

    private static GameObject ResetInfo<T>(T obj, GameObject canvas)
    {
        GameObject.Destroy(UI);
        return GameObject.Instantiate(template, canvas.transform);
    }

    public static void RemoveInfo()
    {
        GameObject.Destroy(UI);
    }

    private static void SetText(UIDocument UI, string name, string text)
    {
        VisualElement elementParent = UI.rootVisualElement.Q(name) as VisualElement;
        Label element = UI.rootVisualElement.Q(name+"_value") as Label;

        if (element == null)
        {
            Debug.LogError($"Error! The child of name '{name}' was not found.");
            return;
        }
        if (text != null)
        {
            element.text = text;
            if(elementParent != null)
            {
                elementParent.style.display = DisplayStyle.Flex;
                elementParent.style.visibility = Visibility.Visible;
            }
        }
    }
}