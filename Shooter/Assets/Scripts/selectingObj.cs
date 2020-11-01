using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectingObj : MonoBehaviour
{

    public int buttonNum;
    public GameObject invent;

    [HideInInspector]
    public Inventory inventory;

    void Awake()
    {
        inventory = invent.GetComponent<Inventory>();
    }

    public void select(Inventory inventory)
    {
        if (inventory.inventoryArray[buttonNum - 1] != inventory.GO)
        {
            inventory.selected = buttonNum;
            inventory.inventoryArray[inventory.selected].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.GetComponent<RawImage>().color = new Color(
                inventory.inventoryArray[inventory.selected].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.GetComponent<RawImage>().color.r,
                inventory.inventoryArray[inventory.selected].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.GetComponent<RawImage>().color.g,
                inventory.inventoryArray[inventory.selected].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.GetComponent<RawImage>().color.b, 150);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < inventory.inventoryArray.Length; i++)
        {
            if (inventory.inventoryArray[i] != inventory.GO)
            {
                RawImage image = inventory.inventoryArray[i].GetComponent<settingObject>().button.GetComponent<pickUping>().icon.GetComponent<RawImage>();
                if (i + 1 == inventory.selected)
                {
                    image.color = new Color(
                        image.color.r,
                        image.color.g,
                        image.color.b, 0.7f);
                }
                else
                {
                    image.color = new Color(
                        image.color.r,
                        image.color.g,
                        image.color.b, 255);
                }
            }
        }
    }
}
