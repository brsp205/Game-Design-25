using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicMovement : MonoBehaviour
{

    private Camera cam;
    public static Vector3 externpos;    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        //If arrows or wasd are pressed Stopped variable set to 0 to start animation
        if (Math.Abs(Input.GetAxis("Vertical"))+Math.Abs(Input.GetAxis("Horizontal")) == 0)
        {
            animator.SetInteger("Stopped",1);
        }
        else
        {
            animator.SetInteger("Stopped",0);
        }

        float speed = 8f; // run speed

        Vector3 horizontal  = new Vector3(Input.GetAxis("Horizontal")   , Input.GetAxis("Vertical") , 0.0f);
        transform.position  = transform.position + horizontal * Time.deltaTime * speed;
        //Public variable that is visible to other classes. Contains Vector3 format: (x,y,z) of the character in game units
        externpos = transform.position;

        //Get mouseinput in pixels
        Vector3 mouse = Input.mousePosition;
            //Debug.Log("Mouse Input " + mouse.ToString("F3")); //Prints mouse to console 
        //Convert mouseinput to game units
        Vector3 point = cam.ScreenToWorldPoint(mouse);
            //Debug.Log("Point " + point.ToString("F3"));   //Prints point to console

        double interx = point.x - transform.position.x ; //difference between mouse and character location
        double intery = point.y - transform.position.y ;
        Vector3 rota = new Vector3(0.0f , 0.0f , Convert.ToSingle(Math.Atan2(intery,interx)/Math.PI*180) );//atan2
        float rotb = transform.eulerAngles.z;
            //Debug.Log("rotaZ " + rota.z.ToString("F3"));
            //Debug.Log("rota read " + transform.eulerAngles.ToString("F3"));
        transform.Rotate(0.0f , 0.0f , rota.z-rotb,Space.Self);


    }
    
}
