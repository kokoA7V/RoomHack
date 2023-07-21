using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClickTimingManager : MonoBehaviour
{
    public int level = 8;
    public int time = 15;
    public float countTime = 0.25f;
    public int rand = 75;
    public bool clearflag=false;

    public GameObject rod, pointer;
    public Text text;

    private float r;
    private float timer = 0;
    private int count = 0;
    private float countTimer = 0;
    private int point = 0;
    private int poiFlg = 1;

    private GameObject[] rodObj;
    private GameObject[] poiObj;

    private bool[] checkFlg;

    void Start()
    {
        rodObj = new GameObject[level];
        poiObj = new GameObject[level];
        checkFlg = new bool[level];

        r = 360.0f / level;
        text.fontSize = 250;
        text.text = time.ToString();

        for (int i = 0; i < level; i++)
        {
            GameObject tmp = Instantiate(rod, transform.position, Quaternion.identity);
            tmp.transform.parent = this.transform;
            rodObj[i] = tmp;
            rodObj[i].GetComponent<Transform>().Rotate(0, 0, r * count);

            tmp = Instantiate(pointer, transform.position, Quaternion.identity);
            tmp.transform.parent = this.transform;
            poiObj[i] = tmp;
            poiObj[i].GetComponent<Transform>().Rotate(0, 0, r * count);

            checkFlg[i] = (Random.value > rand * 0.01f);

            if (checkFlg[i]) rodObj[i].SetActive(false);

            count++;
        }

        poiObj[point].GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

    void Update()
    {
        if (checkFlg.All(b => b))
        {
            clearflag = true;
            text.fontSize = 150;
            text.text = "âèú";
            return;
        }
        else if (time <= 0)
        {
            text.fontSize = 150;
            text.text = "é∏îs";
            return;
        }
        else
        {
            //écÇËéûä‘
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 0;
                time--;
                text.text = time.ToString();
            }

            countTimer += Time.deltaTime;
            if(countTimer >= countTime)
            {
                countTimer = 0;

                poiObj[point].GetComponentInChildren<SpriteRenderer>().color = Color.white;

                point += poiFlg;
                if (point < 0) point = level - 1;
                if (point >= level) point = 0;

                poiObj[point].GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (rodObj[point].activeSelf)
                {
                    rodObj[point].SetActive(false);
                    checkFlg[point] = true;
                }
                else
                {
                    rodObj[point].SetActive(true);
                    checkFlg[point] = false;
                }
                
                poiFlg *= -1;
            }
        }
    }
}
