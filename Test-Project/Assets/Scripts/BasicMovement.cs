using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicMovement : MonoBehaviour
{

    private Camera cam;
    public static Vector3 externpos; 
    public static float externrot;   
    public static int level;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        level = 1;
    }

    public Animator animator;
    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        //ANIMATION CONDITION
        //If arrows or wasd are pressed Stopped variable set to 0 to start animation
        if (Math.Abs(Input.GetAxis("Vertical"))+Math.Abs(Input.GetAxis("Horizontal")) == 0)
        {
            animator.SetInteger("Stopped",1);
        }
        else
        {
            animator.SetInteger("Stopped",0);
        }
        //LEVELS
        float Arrtrigger = 1.5f; //proximity trigger distance from characterPos to ArrowPos
        int maxlevel = 3;
        Vector3 TPto = new Vector3(12.5f,-12.7f,0);
        //Arrow down
        double ADlength = Math.Sqrt(Math.Pow(transform.position.x-ArrowDown.Startpos.x,2)+Math.Pow(transform.position.y-ArrowDown.Startpos.y,2));
        ADlength = Convert.ToSingle(ADlength);
        if (ADlength <= Arrtrigger){
            if (level > 1){
                level = level - 1;
                transform.position = TPto;
            }
        }
        //Arrow up
        double AUlength = Math.Sqrt(Math.Pow(transform.position.x-ArrowUp.Startpos.x,2)+Math.Pow(transform.position.y-ArrowUp.Startpos.y,2));
        AUlength = Convert.ToSingle(AUlength);
        if (AUlength <= Arrtrigger){
            if (level < maxlevel){
                level = level + 1;
                transform.position = TPto;
            }
        }

        



        Debug.Log("BM level " + level.ToString("F3"));


    }

    void FixedUpdate () {
        float speed = 14f;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")   , Input.GetAxis("Vertical") , 0.0f).normalized;
        body.velocity = new Vector2(movement.x*speed,movement.y*speed);
        //Public variable that is visible to other classes. Contains Vector3 format: (x,y,z) of the character in game units
        externpos = transform.position;
        //Debug.Log("Input " + Input.GetAxis("Horizontal").ToString("F3"));
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
        externrot = transform.eulerAngles.z;
            //Debug.Log("rotaZ " + rota.z.ToString("F3"));
            //Debug.Log("rota read " + transform.eulerAngles.ToString("F3"));
        transform.Rotate(0.0f , 0.0f , rota.z-rotb,Space.Self);
    }
    
}
