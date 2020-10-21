using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectingObj : MonoBehaviour
{

    public int buttonNum;

    public void select(Inventory inventory)
    {
        if (inventory.inventoryArray[buttonNum - 1] != inventory.GO)
        {
            inventory.selected = buttonNum;
        }
    }
}
