using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL3 : MonoBehaviour
{
    public static Vector3 Startpos;
    // Start is called before the first frame update
    void Start()
    {
    Startpos = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        int THISLEVELNR = 3;
        Vector3 foreground = new Vector3(Startpos.x , Startpos.y , 0.1f);
        Vector3 background = new Vector3(Startpos.x , Startpos.y , 0.11f);
        if (BasicMovement.level == THISLEVELNR && transform.position.z != foreground.z){
                transform.position = foreground;
        }
        else if (BasicMovement.level != THISLEVELNR && transform.position.z != background.z){
            transform.position = background;
        }

    }
}
