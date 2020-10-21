using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class throwingAway : MonoBehaviour
{

    public GameObject joystick;
    public GameObject camera;
    public GameObject inventory;
    public Toggle toggle;
    public float Speed;

    [HideInInspector]
    public moving joystickSc;
    [HideInInspector]
    public Inventory invSc;
    [HideInInspector]
    public movingCamera camSc;
    [HideInInspector]
    public bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Screen.width / 60 / 8, Screen.width / 60 / 8, 1.0f);
        transform.position = new Vector3(Screen.width * 0.93f, Screen.height * 0.15f, 0.0f);
        joystickSc = joystick.GetComponent<moving>();
        invSc = inventory.GetComponent<Inventory>();
        camSc = camera.GetComponent<movingCamera>();
    }

    void FixedUpdate()
    {
        if (isPressed)
        {
            camera.transform.position = Vector3.Lerp(transform.position,
                 new Vector3(camSc.player.transform.position.x, camera.transform.position.y, camSc.player.transform.position.z),
                 Speed * Time.deltaTime);
            camera.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(180, 0, 0), Speed * Time.deltaTime);
        }
    }

    public void Throwing()
    {
        if (invSc.selected != 0 && !isPressed)
        {
            joystickSc.isThrowing = true;
            camSc.isThrowing = true;
            isPressed = true;
        }
    }
}
