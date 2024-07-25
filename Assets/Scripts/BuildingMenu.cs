using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    
    void Start()
    {
        string[] buildingTypes = AssetDatabase.GetSubFolders("Assets/Scripts/Structures/Buildings");
        Dictionary<string, List<string>> list;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
