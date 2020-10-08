using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Math.Abs(Input.GetAxis("Vertical"))+Math.Abs(Input.GetAxis("Horizontal")));
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        float speed = 4f;
        //Vector3 speeds      = new Vector3(0.3f,0.3f,0.3f);
        Vector3 horizontal  = new Vector3(Input.GetAxis("Horizontal")   , 0.0f                      , 0.0f);
        Vector3 vertical    = new Vector3(0.0f                          , Input.GetAxis("Vertical") , 0.0f);
        transform.position  = transform.position + horizontal * Time.deltaTime * speed;
        transform.position  = transform.position + vertical * Time.deltaTime * speed;
    }
}
