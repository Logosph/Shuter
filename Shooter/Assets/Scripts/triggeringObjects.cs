using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class triggeringObjects : MonoBehaviour
{

    public GameObject dialogue;
    public GameObject text;
    public float radius;

    [HideInInspector]
    public RawImage image;

    [HideInInspector]
    public Text textObj;

    [HideInInspector]
    public GameObject collidedObj;

    [HideInInspector]
    public bool isCollided = false;

    void Start()
    {
        image = dialogue.GetComponent<RawImage>();
        textObj = text.GetComponent<Text>();
        dialogue.transform.position = transform.position + new Vector3(0, radius * 10, 0);
    }

    private void OnTriggerEnter(Collider Obj)
    {
        if (Obj.tag == "Player")
        {
            isCollided = true;
            collidedObj = Obj.gameObject;
            image.color = new Color(255, 255, 255, 255);
            textObj.color = new Color(0, 0, 0, 255);

        }
    }
    private void OnTriggerExit(Collider Obj)
    {
        if (Obj.tag == "Player")
        {
            isCollided = false;
            collidedObj = new GameObject();
            image.color = new Color(255, 255, 255, 0);
            textObj.color = new Color(255, 255, 255, 0);
        }
    }
}
