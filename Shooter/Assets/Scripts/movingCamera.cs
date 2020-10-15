using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class movingCamera : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z + 80);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 80);
        }
    }
}
