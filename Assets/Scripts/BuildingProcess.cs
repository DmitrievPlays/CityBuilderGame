using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class BuildingProcess : MonoBehaviour
{
    GameObject cursorBuilding, objToBuild;
    Vector3 cursorWorldPos;
    Camera cam;
    Plane plane = new Plane(Vector3.up, 0);
    bool canBeBuiltHere = false;
    Action a;

    void Start()
    {
        cam = Camera.main;
        a = () => { Build(RoundPosition(cursorWorldPos)); };
    }


    void Update()
    {
        if (cursorBuilding == null)
            return;

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
            cursorWorldPos = ray.GetPoint(distance);
        cursorBuilding.transform.position = RoundPosition(cursorWorldPos);
    }

    public void SetObjectToBuild(GameObject obj)
    {
        CancelBuilding();
        Events.instance.Subscribe("LClick", a);
        cursorBuilding = Instantiate(obj);
        objToBuild = Instantiate(obj);
        Destroy(cursorBuilding.GetComponent<Collider>());
    }

    Vector3 RoundPosition(Vector3 pos)
    {
        return new Vector3((float)Math.Round(pos.x), pos.y, (float)Math.Round(pos.z));
    }

    private void Build(Vector3 coords)
    {
        if (!CanBeBuiltHere())
        {
            Camera.main.transform.GetComponent<MessageService>()
                .SendMessage("Cannot build here!");
            return;
        }
        GameObject placedObject = Instantiate(objToBuild);
        placedObject.transform.position = coords;
        Economy.instance.PayMoney(placedObject.GetComponent<IStructure>().GetPlacementCost());
    }

    public void CancelBuilding()
    {
        Events.instance.Unsubscribe("LClick", a);
        Destroy(cursorBuilding);
    }


    bool CanBeBuiltHere()
    {
        return !IsColliding();
    }


    bool IsColliding()
    {
        Renderer renderer = cursorBuilding.transform.GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;
        LayerMask mask = LayerMask.GetMask("Default");

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.extents, cursorBuilding.transform.rotation, mask);
        Debug.Log(colliders.Length.ToString());
        foreach (Collider c in colliders)
        {
            Debug.Log(c.name);
        }
        //Debug.Log(stringBuilder.ToString());
        // Debug.Log(a[0]?.gameObject.name + "/" + a[1]?.gameObject.name + "/" + a[2]?.gameObject.name);

        return colliders.Length > 0;
    }
}
