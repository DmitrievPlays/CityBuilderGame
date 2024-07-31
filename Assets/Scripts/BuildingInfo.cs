using UnityEngine;
using UnityEngine.UIElements;

public static class BuildingInfo
{
    private static GameObject template = Resources.Load<GameObject>("Prefabs/BuildingInfo");
    private static GameObject selection = Resources.Load<GameObject>("Prefabs/Selection");
    private static GameObject selSpawned;

    private static UIDocument UI;
    static AudioClip clipOpen = (AudioClip)Resources.Load("Sounds/bubble_open");

    //static AudioClip clipClose = (AudioClip)Resources.Load("Sounds/bubble_close");
    /// <summary>
    /// Show a popup with properties of the selected building.
    /// </summary>
    public static void ShowInfo<T>(T obj, GameObject canvas)
    {
        if(UI != null)
        {
            GameObject.Destroy(canvas.transform.Find(UI.name)?.gameObject);
            GameObject.Destroy(selSpawned);
        }
        if (obj == null)
            return;
            

        if (obj as IStructure == null) return;

        UI = ResetInfo(obj, canvas).GetComponent<UIDocument>();

        selSpawned = GameObject.Instantiate(selection);
        selSpawned.transform.localScale = (obj as MonoBehaviour).transform.GetComponent<BoxCollider>().bounds.size;
        selSpawned.transform.position = (obj as MonoBehaviour).transform.GetComponent<BoxCollider>().transform.
            TransformPoint((obj as MonoBehaviour).transform.GetComponent<BoxCollider>().center);

        Camera.main.GetComponent<AudioSource>().PlayOneShot(clipOpen);

        SetText(UI, "name", (obj as IStructure)?.GetName());
        SetText(UI, "descr", (obj as IStructure)?.GetDescription());
        SetText(UI, "water", (obj as IWaterConsumer)?.GetWaterDemand().ToString());
        SetText(UI, "energy", (obj as IEnergyConsumer)?.GetEnergyDemand().ToString());

        UI.transform.SetParent(canvas.transform, false);
        UI.rootVisualElement.Q("destroy").RegisterCallback<ClickEvent>((e) => (obj as IDestructible)?.Destroy());
    }

    private static GameObject ResetInfo<T>(T obj, GameObject canvas)
    {
        GameObject.Destroy(selSpawned);
        GameObject.Destroy(UI);
        return GameObject.Instantiate(template, canvas.transform);
    }

    public static void RemoveInfo()
    {
        GameObject.Destroy(selSpawned);
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