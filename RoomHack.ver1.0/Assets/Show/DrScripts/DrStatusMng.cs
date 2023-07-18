using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrStatusMng : MonoBehaviour, IDoorHackUnit
{
    //DoorのUI表示スクリプト
    public bool DrHacked { get; set; } = false;
    public GameObject DoorObj;
    public GameObject gimmick;
    public door doorSc;
    bool isclearflag = false;

    GameObject buttonObj;
    DrButtonController bc;

    bool unhackCrick = false;

    Transform canvasTrans;

    [SerializeField] GameObject DrUnhackImage;
    [SerializeField] GameObject DrHackImage;
    [SerializeField] GameObject DrButtonPre;
    [SerializeField] GameObject Canvas;

    void Start()
    {
        canvasTrans = Canvas.transform;
    }
    void Update()
    {
        DrStatusDisp();
        Debug.Log("q");
    }
    public void DrStatusDisp()
    {
        if (gimmick != null)
        {
            isclearflag = gimmick.GetComponent<CircleArrowManager>().clearflag;
        }
        if (isclearflag)
        {
            doorSc.hacked = true;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        Debug.Log(hit.collider);

        if (Input.GetMouseButtonDown(0) &&  hit.collider != null && hit.collider.gameObject == DoorObj && !unhackCrick)
        {
            doorSc = hit.collider.gameObject.GetComponent<door>();

            if (!doorSc.hacked) //まだHackしていない。
            {
                // UI表示
                GameObject unhackdr = Instantiate(DrUnhackImage, canvasTrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -200, 0);

                // ボタン生成
                buttonObj = Instantiate(DrButtonPre, canvasTrans);
                RectTransform buttonpos = buttonObj.GetComponent<RectTransform>();
                gimmick = buttonObj.GetComponent<DrButtonController>().gimmickObj;

                buttonpos.anchoredPosition = new Vector3(700, -230, 0);
                bc = buttonObj.GetComponent<DrButtonController>();
                unhackCrick = true;
            }
            else //Hackし終わった後の処理
            {
                // UI表示
                GameObject hackdr = Instantiate(DrHackImage, canvasTrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -200, 0);
            }
        }
    }
}
