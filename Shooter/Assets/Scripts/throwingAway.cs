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

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Screen.width / 60 / 8, Screen.width / 60 / 8, 1.0f);
        transform.position = new Vector3(Screen.width * 0.93f, Screen.height * 0.15f, 0.0f);
        joystickSc = joystick.GetComponent<moving>();
        invSc = inventory.GetComponent<Inventory>();
        camSc = camera.GetComponent<movingCamera>();
    }

    public void Throwing()
    {
        if (invSc.selected != 0)
        {
            invSc.inventoryArray[invSc.selected - 1].transform.position = 
                new Vector3(camSc.player.transform.position.x,
                1,
                camSc.player.transform.position.z);
            invSc.inventoryArray[invSc.selected - 1].GetComponent<settingObject>().canvas.transform.position =
                invSc.inventoryArray[invSc.selected - 1].transform.position + 
                new Vector3(0, invSc.inventoryArray[invSc.selected - 1].GetComponent<triggeringObjects>().radius * 10, 0);
            invSc.inventoryArray[invSc.selected - 1].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.transform.position = 
                new Vector3(-100, -100, -100);
            invSc.inventoryArray[invSc.selected - 1] = invSc.GO;
            invSc.selected = 0;
        }

    }
}
