using TMPro;
using UnityEngine;

public static class BuildingInfo
{
    private static GameObject template = Resources.Load<GameObject>("Prefabs/BuildingInfo");

    /// <summary>
    /// Show a popup with properties of the selected building.
    /// </summary>

    public static void ShowInfo<T>(T obj, GameObject canvas)
    {
        GameObject UI = Object.Instantiate(template);
        Object.Destroy(canvas.transform.Find(UI.name)?.gameObject);

        if (obj as IStructure == null) return;

        SetText(UI, "Panel/name", (obj as IStructure)?.GetName());
        SetText(UI, "Panel/descr", (obj as IStructure)?.GetDescription());
        SetText(UI, "Panel/other/water", (obj as IWaterConsumer)?.GetWaterDemand().ToString());
        SetText(UI, "Panel/other/energy", (obj as IEnergyConsumer)?.GetEnergyDemand().ToString());

        UI.transform.SetParent(canvas.transform, false);
        UI.SetActive(true);
    }

    private static void SetText(GameObject UI, string path, string text)
    {
        Transform element = UI.transform.Find(path);

        if(element == null)
        {
            Debug.LogError($"Error! The child at path {path} was not found.");
            return;
        }
        element.GetComponent<TMP_Text>().text = text;
        element.gameObject.SetActive(true);
    }
}
