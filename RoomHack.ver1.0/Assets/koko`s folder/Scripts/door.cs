using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour, IUnitHack
{
    // インターフェース
    public bool hacked { get; set; } = false;

    public int doorSize = 1;
    public bool isUD = true;

    GameObject doorUorL;
    GameObject doorDorR;

    GameObject dUL_Mate;
    GameObject dUL_Enemy;
    GameObject dDR_Mate;
    GameObject dDR_Enemy;

    float moveValue = 0;
    //float moveSpd = 1;

    bool open = false;
    bool close = true;

    void Start()
    {
        doorUorL = transform.GetChild(0).gameObject;
        doorDorR = transform.GetChild(1).gameObject;

        dUL_Mate = doorUorL.transform.GetChild(0).gameObject;
        dUL_Enemy = doorUorL.transform.GetChild(1).gameObject;
        dDR_Mate = doorDorR.transform.GetChild(0).gameObject;
        dDR_Enemy = doorDorR.transform.GetChild(1).gameObject;

        if (doorSize == 1)
        {
            moveValue = 0.25f;
        }
    }

    void Update()
    {
        if (hacked)
        {
            dUL_Mate.SetActive(true);
            dUL_Enemy.SetActive(false);
            dDR_Mate.SetActive(true);
            dDR_Enemy.SetActive(false);
        }
        else
        {
            dUL_Mate.SetActive(false);
            dUL_Enemy.SetActive(true);
            dDR_Mate.SetActive(false);
            dDR_Enemy.SetActive(true);
        }

        // デバッグ用
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

    public void DoorOpen()
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

    public void DoorClose()
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

    // インターフェース
    public void StatusDisp()
    {

    }
}
