using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArrowUp : MonoBehaviour
{
    private int counter;
    private int dcounter;
    public static Vector3 Startpos;

    // Start is called before the first frame update
    void Start()
    {
    counter = 1;
    dcounter = 1;
    Startpos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        int maxlevel = 3; //highest floor
        Vector3 foreground = new Vector3(Startpos.x , Startpos.y , 0.05f);
        Vector3 background = new Vector3(Startpos.x , Startpos.y , 0.11f);
        if (BasicMovement.level != maxlevel)
        {
            if (transform.position.z == background.z){
                transform.position = foreground;
            }
            //Animation
            float movement = 1.0f;
            int numberosteps = 100;
            if (dcounter > 0){
                if (counter == numberosteps){
                    dcounter = -1;
                }
            }
            else if (dcounter < 0){
                    if (counter == 1){
                    dcounter = 1;
                }
            }
            counter = counter + dcounter;
            Vector3 anim = new Vector3(0.0f , counter*(movement/numberosteps) , 0.0f);
            transform.position = Startpos - anim;

        }
        else if (transform.position.z == foreground.z){
            transform.position = Startpos;
            transform.position = background;
        }
    }
}
