using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Tyou;
    public GameObject Tch;
    public GameObject Tdia;
    string[] Names = {"Barry", "Larry", "Cheryl", "Daffodil","Harry"};
    float[] Xch = {7.35f,-19f,21.41f,12.32f,22.33f};
    float[] Ych = {-19.33f,14.69f,3.88f,11.02f,-13.61f};
    int[] LEVELch = {3,2,2,1,1};
    int[] STATEch = {0,0,0,0,0};
    public static int index;
    public static bool cutscene; 



    // Start is called before the first frame update
    void Start()
    {
        cutscene = false; // false = no cutscene is activated/playing
        Panel = transform.GetChild(0).gameObject;
        Tyou = transform.GetChild(1).gameObject;
        Tch = transform.GetChild(2).gameObject;
        Tdia = transform.GetChild(3).gameObject;
        Panel.SetActive(false);
        Tyou.SetActive(false);
        Tch.SetActive(false);
        Tdia.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i=0 ; i<Names.Length ; i++)
            {
                if (BasicMovement.level == LEVELch[i] && Math.Sqrt(Math.Pow(Xch[i]-BasicMovement.externpos.x,2)+Math.Pow(Ych[i]-BasicMovement.externpos.y,2))<=5 )
                {
                    cutscene = true;
                    index = i;
                    break;
                }
            }
        Debug.Log("Character " + index.ToString("F3") + cutscene);

            if (cutscene == true)
            {
                Panel.SetActive(true);
                Tyou.SetActive(true);
                Tch.SetActive(true);
                Tdia.SetActive(true);

            }

        }
        



    }
}
