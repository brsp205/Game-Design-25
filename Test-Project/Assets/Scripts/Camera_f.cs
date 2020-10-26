using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Camera_f : MonoBehaviour
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
        float magX = 0.3f; 
        float magY = 0.15f;
        //double length = Math.Sqrt(Math.Pow(transform.position.x-BasicMovement.externpos.x,2)+Math.Pow(transform.position.y-BasicMovement.externpos.y,2));
        
        Vector3 movecam  = new Vector3((BasicMovement.externpos.x-transform.position.x)/magX , (BasicMovement.externpos.y-transform.position.y)/magY , 0.0f);
        transform.position  = transform.position + movecam*Time.deltaTime;
        //Debug.Log("Char Pos " + movecam.ToString("F3"));

        if (CharacterController.cutscene == true)
        {
            cam.orthographicSize = 4;
        }
        else
        {
            cam.orthographicSize = 10;
        }
        


    }
}

