using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseHandler : MonoBehaviour
{
    private InputSystem_Actions actions;

    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction moveAction;
    private InputAction b;

    GameObject buildingInfoUI;



    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    void Start()
    {
        buildingInfoUI = GameObject.Find("Canvas");
    }

    private void OnEnable()
    {
        leftClick = actions.UI.Click;
        rightClick = actions.UI.RightClick;
        moveAction = actions.Player.Move;
        b = actions.Player.B0;

        leftClick.Enable();
        rightClick.Enable();
        moveAction.Enable();
        b.Enable();

        moveAction.performed += WPressed;
        leftClick.performed += Click;
        rightClick.performed += RightClick;
        b.performed += BPressed;
    }


    private void Click(InputAction.CallbackContext context)
    {
        Events.instance.TriggerEvent("LClick");
        RaycastHit hit;

        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "PanelSettings")
                return;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            BuildingInfo.ShowInfo(hit.collider.transform.GetComponent<MonoBehaviour>(), buildingInfoUI);
        }
    }

    private void RightClick(InputAction.CallbackContext context)
    {

    }

    private void WPressed(InputAction.CallbackContext context)
    {

    }

    private void BPressed(InputAction.CallbackContext context)
    {
        Events.instance.TriggerEvent("toggleMenu");
    }

    Vector2 temp;
    float multiplier = 5f;

    void Update()
    {
        //temp += Time.deltaTime * moveAction.ReadValue<Vector2>() * multiplier;
        //Camera.main.transform.position = new Vector3(Camera.main.transform.forward.x, 8, Camera.main.transform.forward.z) * multiplier * Time.deltaTime;
    }
}
