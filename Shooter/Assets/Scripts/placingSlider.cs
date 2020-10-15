using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class placingSlider : MonoBehaviour
{

    public RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        transform.position = new Vector3((float)(Screen.width * 0.95), (float)(Screen.height / 2), 0.0f);
        //rt.height = Screen.height * 0.9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
