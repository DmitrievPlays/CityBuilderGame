using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class BuildingProcess : MonoBehaviour
{
    GameObject cursorBuilding;
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
        if (Economy.instance.GetBalance(Material.MONEY) < cursorBuilding.GetComponent<IStructure>().GetPlacementCost())
        {
            Camera.main.transform.GetComponent<MessageService>()
                .SendMessage("Not enough money to build the building!");
            return;
        }

        GameObject placedObject = Instantiate(cursorBuilding);
        placedObject.transform.position = coords;
        Economy.instance.PayMaterial(Material.MONEY, placedObject.GetComponent<IStructure>().GetPlacementCost());
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
        Collider collider = cursorBuilding.transform.GetComponent<Collider>();
        Bounds bounds = collider.bounds;
        LayerMask mask = LayerMask.GetMask("Default");

        return Physics.OverlapBox(bounds.center, bounds.extents, cursorBuilding.transform.rotation, mask).Length > 1;
    }
}
