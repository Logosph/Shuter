using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class moving : MonoBehaviour
{
    public GameObject Player;
    public GameObject touchMarker;
    public float length;
    public float speed;

    [HideInInspector]
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        touchMarker.transform.position = transform.position + new Vector3(0, 0, -10);
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                transform.position = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 shift = new Vector3(touch.position.x, touch.position.y, transform.position.z) - transform.position;
                if (shift.magnitude <= length)
                {
                    touchMarker.transform.position = touch.position;
                }
                else
                {
                    touchMarker.transform.position = shift.normalized * length + transform.position;
                }
                double angle = Math.Atan(shift.normalized.y / shift.normalized.x)*180/Math.PI - 90;
                if (angle < 0)
                {
                    angle =  Math.Abs(angle);
                }    
                if (shift.x < 0)
                {
                    angle += 180;
                }
                Vector3 movement = new Vector3(shift.normalized.x, 0, shift.normalized.y);
                Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, (float)angle, Player.transform.rotation.eulerAngles.z);
                Player.transform.Translate(movement * speed * Time.fixedDeltaTime);

            }

        }
    }
}
