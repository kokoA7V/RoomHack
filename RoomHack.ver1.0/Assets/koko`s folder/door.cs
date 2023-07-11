using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public int doorSize = 1;
    public bool isUD = true;

    GameObject doorUorL;
    GameObject doorDorR;

    float moveValue = 0;
    float moveSpd = 1;

    bool open = false;
    bool close = true;

    // Start is called before the first frame update
    void Start()
    {
        doorUorL = transform.GetChild(0).gameObject;
        doorDorR = transform.GetChild(1).gameObject;

        if(doorSize == 1)
        {
            moveValue = 0.16f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (open)
            {
                DoorClose();
            }
            else if (close)
            {
                DoorOpen();
            }
            else
            {
                // Debug.Log("fuck");
            }
        }
    }

    void DoorOpen()
    {
        if (close == true)
        {
            close = false;

            Vector3 pos = doorUorL.transform.position;
            if (isUD)
            {
                pos.y += moveValue;
            }
            else
            {
                pos.x -= moveValue;
            }
            doorUorL.transform.position = pos;

            pos = doorDorR.transform.position;
            if (isUD)
            {
                pos.y -= moveValue;
            }
            else
            {
                pos.x += moveValue;
            }
            doorDorR.transform.position = pos;

            open = true;
        }
    }

    void DoorClose()
    {
        if (open == true)
        {
            open = false;

            Vector3 pos = doorUorL.transform.position;
            if (isUD)
            {
                pos.y -= moveValue;
            }
            else
            {
                pos.x += moveValue;
            }
            doorUorL.transform.position = pos;

            pos = doorDorR.transform.position;
            if (isUD)
            {
                pos.y += moveValue;
            }
            else
            {
                pos.x -= moveValue;
            }
            doorDorR.transform.position = pos;

            close = true;
        }
    }
}
