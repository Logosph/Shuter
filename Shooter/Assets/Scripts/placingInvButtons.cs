using System;
using System.Collections;
using UnityEngine;

public class placingInvButtons : MonoBehaviour
{

    public int number;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Screen.width * (11 + number * 2) / 32, Screen.height * 0.1f, 0.0f);
        transform.localScale = new Vector3((float)(Screen.width / 233.7 / 4.5), (float)(Screen.width / 233.7 / 4.5), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
