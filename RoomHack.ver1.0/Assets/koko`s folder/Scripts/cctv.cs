using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctv : MonoBehaviour, IUnitHack
{
    public bool hacked { get; set; } = false;

    GameObject mosic;
    public GameObject mosicPre;

    GameObject CCTV_Mate;
    GameObject CCTV_Enemy;

    public Vector2 areaPos;

    private void Start()
    {
        mosic = transform.GetChild(0).gameObject;
        CCTV_Mate = transform.GetChild(1).gameObject;
        CCTV_Enemy = transform.GetChild(2).gameObject;

        Vector2 startPos = this.transform.position;
        startPos.x += areaPos.x < 0 ? areaPos.x : 0;
        startPos.y += areaPos.y < 0 ? areaPos.y : 0;

        Vector2 endPos = this.transform.position;
        endPos.x += areaPos.x > 0 ? areaPos.x : 0;
        endPos.y += areaPos.y > 0 ? areaPos.y : 0;

        //Debug.Log("start" + startPos);
        //Debug.Log("end" + endPos);

        Vector2 nowPos;

        for (nowPos.x = startPos.x; nowPos.x <= endPos.x; nowPos.x++)
        {
            for (nowPos.y = startPos.y; nowPos.y <= endPos.y; nowPos.y++)
            {
                GameObject temp = (GameObject)Instantiate(mosicPre, nowPos, Quaternion.identity);
                temp.transform.parent = mosic.transform;
            }
        }
    }

    private void Update()
    {
        if (hacked)
        {
            CCTV_Mate.SetActive(true);
            CCTV_Enemy.SetActive(false);

            mosic.SetActive(false);
        }
        else
        {
            CCTV_Mate.SetActive(false);
            CCTV_Enemy.SetActive(true);

            mosic.SetActive(true);
        }
    }

    public void StatusDisp()
    {

    }
}
