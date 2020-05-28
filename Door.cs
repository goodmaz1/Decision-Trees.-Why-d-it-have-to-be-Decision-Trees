using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool closed = true;
    public bool locked = true;

    Vector3 closedRotation = new Vector3(0, 0, 0); //values + Code for opening/ closing door taken from Prof Slease's gitHub, because animating is hard and this is way easier than what I was trying at first
    Vector3 openRotation = new Vector3(0, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
        if (closed == true)
        {
            transform.eulerAngles = closedRotation; //again, taken from Prof Slease's code
        }
        else if(closed == false)
        {
            transform.eulerAngles = openRotation;
        }

    }

   

    public bool open()
    {
        bool didItWork = false; 

        if (closed == true)
        {
            if(locked == false)
            {
                transform.eulerAngles = openRotation;
                closed = false;
                didItWork = true;
            }
        }
        return didItWork; 
    }

    public bool close()
    {
        bool didItWork = false;

        if (closed == false)
        {
            
                transform.eulerAngles = closedRotation;
                closed = true;
                didItWork = true;
            
        }
        return didItWork;  //returns true if the door did close or false if not
    }




}
