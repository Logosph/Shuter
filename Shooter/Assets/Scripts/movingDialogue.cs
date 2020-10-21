using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class movingDialogue : MonoBehaviour
{

    public float defaultPosY;
    public float length;
    public float speed;
    public bool isUp = false;
    public bool isDown = false;
    public float inaccuracy;
    public GameObject button;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.position.y;
        button.transform.position = transform.position;
        text.transform.position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isUp && !isDown)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, defaultPosY - length, transform.position.z), speed * Time.deltaTime);
        }
        else if (!isUp && isDown)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, defaultPosY + length, transform.position.z), speed * Time.deltaTime);
        }
        if (transform.position.y >= defaultPosY + length - inaccuracy)
        {
            isUp = true;
            isDown = false;
        }
        else if (transform.position.y <= defaultPosY - length + inaccuracy)
        {
            isUp = false;
            isDown = true;
        }
    }
}
