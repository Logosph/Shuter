using System;
using System.Collections;
using UnityEngine;

public class pickUping : MonoBehaviour
{

    public GameObject obj;
    [HideInInspector]
    public triggeringObjects trig;

    public GameObject icon;

    public GameObject inventory;

    [HideInInspector]
    public Inventory inv;

    void Start()
    {
        icon.transform.localScale = new Vector3((float)(Screen.width / 233.7 / 4.5), (float)(Screen.width / 233.7 / 4.5), 1.0f);
        icon.transform.position = new Vector3(-100, -100, -100);
        trig = obj.GetComponent<triggeringObjects>();
        inv = inventory.GetComponent<Inventory>();
    }

    public void pickingUp()
    {
        if (trig.isCollided)
        {
            for(int i = 0; i < inv.inventoryArray.Length; i++)
            {
                if (inv.inventoryArray[i] == inv.GO)
                {
                    inv.inventoryArray[i] = obj;
                    icon.transform.position = new Vector3(Screen.width * (13 + 2 * i) / 32, Screen.height * 0.1f, 0.0f);
                    obj.transform.position = new Vector3(-1000, -1000, -1000);
                    break;
                }
                else if (i == inv.inventoryArray.Length - 1)
                {
                    
                }
            }
        }
    }
}
