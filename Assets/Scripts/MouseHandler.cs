using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseHandler : MonoBehaviour
{
    private InputSystem_Actions actions;

    private InputAction leftClick;
    private InputAction moveAction;
    private InputAction b;

    GameObject buildingInfoUI;



    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    void Start()
    {
        Debug.Log("start");
        buildingInfoUI = GameObject.Find("Canvas");
    }

    private void OnEnable()
    {
        leftClick = actions.UI.Click;
        moveAction = actions.Player.Move;
        b = actions.Player.B;

        leftClick.Enable();
        moveAction.Enable();
        b.Enable();

        moveAction.performed += WPressed;
        leftClick.performed += Click;
        b.performed += BPressed;
    }


    private void Click(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            BuildingInfo.ShowInfo(hit.collider.transform.GetComponent<MonoBehaviour>(), buildingInfoUI);
        }
    }

    private void WPressed(InputAction.CallbackContext context)
    {

    }

    private void BPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Open Builder menu");
    }

    Vector2 temp;
    float multiplier = 5f;

    void Update()
    {
        //temp += Time.deltaTime * moveAction.ReadValue<Vector2>() * multiplier;
        //Camera.main.transform.position = new Vector3(Camera.main.transform.forward.x, 8, Camera.main.transform.forward.z) * multiplier * Time.deltaTime;
    }
}
