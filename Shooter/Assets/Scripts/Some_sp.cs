using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingLeft : MonoBehaviour
{
    public void moving(GameObject camera)
    {
        Rigidbody2D rb = camera.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(-100, 0, 0));
    }
}
