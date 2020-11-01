using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class movingCamera : MonoBehaviour
{

    public GameObject player;
    public float shift;
    public Toggle toggle;
    public float Speed;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z + shift);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toggle.isOn)
        {
            shift = 0;
            angle = 90;

        }
        else
        {
            shift = 140;
            angle = 25;
        }
        transforming();

    }

    public void transforming()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - shift),
            Speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle, 0, 0), Speed * Time.deltaTime);

    }
}
