using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cursor : MonoBehaviour
{


    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mouse = Input.mousePosition;
        Vector3 point = cam.ScreenToWorldPoint(mouse);
        transform.position  = new Vector3(point.x,point.y,0.0f);


    }
}
