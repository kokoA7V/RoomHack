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

        GameObject temp = (GameObject)Instantiate(mosicPre, this.transform.position, Quaternion.identity);
        temp.transform.parent = mosic.transform;

        Vector2 length;
        length.x = Mathf.Abs(areaPos.x);
        length.y = Mathf.Abs(areaPos.y);

        Vector2 startPos = this.transform.position;
        startPos.x += areaPos.x < 0 ? areaPos.x : 0;
        startPos.y += areaPos.y < 0 ? areaPos.y : 0;


        for (int i = 0; i < length.x; i++)
        {
            for (int j = 0; j < length.y; j++)
            {

            }
        }
    }

    public void StatusDisp()
    {

    }

}
