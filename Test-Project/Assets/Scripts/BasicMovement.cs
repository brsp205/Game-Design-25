using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicMovement : MonoBehaviour
{

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {

        if (Math.Abs(Input.GetAxis("Vertical"))+Math.Abs(Input.GetAxis("Horizontal")) == 0)
        {
            animator.SetInteger("Stopped",1);
        }
        else
        {
            animator.SetInteger("Stopped",0);
        }

        float speed = 8f;

        Vector3 horizontal  = new Vector3(Input.GetAxis("Horizontal")   , 0.0f                      , 0.0f);
        Vector3 vertical    = new Vector3(0.0f                          , Input.GetAxis("Vertical") , 0.0f);

        transform.position  = transform.position + horizontal * Time.deltaTime * speed;
        transform.position  = transform.position + vertical * Time.deltaTime * speed;


        Vector3 mouse = Input.mousePosition;
        //Debug.Log("Mouse Input " + mouse.ToString("F3"));
        Vector3 point = cam.ScreenToWorldPoint(mouse);
        //Debug.Log("Point " + point.ToString("F3"));
        double interx = point.x - transform.position.x ;
        double intery = point.y - transform.position.y ;
        Vector3 rota = new Vector3(0.0f , 0.0f , Convert.ToSingle(Math.Atan2(intery,interx)/Math.PI*180) );
        float rotb = transform.eulerAngles.z;
        //Debug.Log("rotaZ " + rota.z.ToString("F3"));
        //Debug.Log("rota read " + transform.eulerAngles.ToString("F3"));
        transform.Rotate(0.0f , 0.0f , rota.z-rotb,Space.Self);
        //transform.Rotate(0.0f , 0.0f , 0.01f ,Space.Self);

    }
}
