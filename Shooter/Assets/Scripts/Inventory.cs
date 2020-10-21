using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventoryArray = new GameObject[4];
    public int selected = 0;
    [HideInInspector]
    public GameObject GO;

    // Start is called before the first frame update
    void Start()
    {
        GO = new GameObject();
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            inventoryArray[i] = GO;
        }
        transform.position = new Vector3(Screen.width / 2, Screen.height * 0.1f, 0.0f);
        transform.localScale = new Vector3((float)(Screen.width / 233.7 / 4), (float)(Screen.width / 233.7 / 4), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
