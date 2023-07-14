using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctv : MonoBehaviour, IUnitHack
{
    public bool hacked { get; set; } = false;

    GameObject mosic;
    public GameObject mosicPre;

    public Vector2 areaPos;

    private void Start()
    {
        mosic = transform.GetChild(0).gameObject;

        Vector2 startPos = this.transform.position;
        startPos.x += areaPos.x < 0 ? areaPos.x : 0;
        startPos.y += areaPos.y < 0 ? areaPos.y : 0;

        //GameObject temp = (GameObject)Instantiate(mosicPre, nowPos, Quaternion.identity);
        //temp.transform.parent = mosic.transform;
    }

    public void StatusDisp()
    {

    }

}
