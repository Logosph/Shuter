using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class moving : MonoBehaviour
{
    public GameObject Player;
    public GameObject touchMarker;
    public float length;
    public float accelerate;
    public float speed;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public Rigidbody rb;

    void Start()
    {
        transform.localScale = new Vector3(Screen.width / 200 / 3, Screen.width / 200 / 3, 1);
        transform.position = new Vector3(Screen.width * 0.15f, Screen.height * 0.3f, 0);
        touchMarker.transform.position = transform.position + new Vector3(0, 0, -10);
        anim = Player.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Если произошло нажатие
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Если было нажатие в левой части экрана
            if (touch.position.x < Screen.width / 2 && (touch.phase == TouchPhase.Began))
            {
                //transform.position = touch.position;
            }

            //Если провели по экрану
            if (touch.phase == TouchPhase.Moved && touch.position.x < Screen.width / 2)
            {
                anim.SetBool("run", true);
                //Включаем анимацию ходьбы или бега
                Vector3 shift = new Vector3(touch.position.x, touch.position.y, transform.position.z) - transform.position;

                //Перемещаем маркер нажатия куда надо
                if (shift.magnitude <= length)

                {
                    touchMarker.transform.position = touch.position;
                }
                else
                {
                    touchMarker.transform.position = shift.normalized * length + transform.position;
                }

                //Находим угол поворота, поворачиваем человека и перемещаем его
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
                rb.AddForce(movement * speed * accelerate);
                if (rb.velocity.magnitude >= speed)
                {
                    rb.velocity = movement * speed;
                }


            }
        }
        //Если нажатия нет то возвращаем маркер нажатия к джойстику и останавливаем человека.
        else
        {
            touchMarker.transform.position = transform.position + new Vector3(0, 0, -10);
            anim.SetBool("run", false);
            rb.velocity = new Vector3(0, 0, 0);
        }
        
    }
}
