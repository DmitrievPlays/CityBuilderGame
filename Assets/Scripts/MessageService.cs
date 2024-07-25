using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MessageService : MonoBehaviour
{
    private static GameObject template;
    static GameObject root;

    private void Start()
    {
        template = Resources.Load<GameObject>("Prefabs/Message");
    }

    Coroutine current;

    public void SendMessage(string message)
    {
        if(current!=null) 
            StopCoroutine(current);
        Destroy(root);
        root = GameObject.Instantiate(template);
        
        Label l = root.GetComponent<UIDocument>().rootVisualElement.Q("message-text") as Label;
        l.text = message;
        current = StartCoroutine(ExecuteAfterTime(4));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(root);
    }
}
