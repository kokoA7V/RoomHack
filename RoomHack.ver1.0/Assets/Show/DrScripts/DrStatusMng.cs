using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrStatusMng : MonoBehaviour
{
    public bool DrHacked = false;
    public GameObject DoorObj;
    GameObject drgimmick;
    public door doorSc;
    bool isclearflag;


    GameObject buttonhackObj;
    GameObject buttonObj;
    GameObject drhb;

    DrButtonController bc;
    

    bool unhackCrick = false;

    Transform canvasTrans;

    [SerializeField] GameObject DrUnhackImage;
    [SerializeField] GameObject DrHackImage;
    [SerializeField] GameObject DrButtonPre;
    [SerializeField] GameObject DrHackButtonPre;
    [SerializeField] GameObject Canvas;

    void Start()
    {
        canvasTrans = Canvas.transform;
        doorSc = gameObject.GetComponent<door>();
    }
    void Update()
    {
        DrStatusDisp();
    }
    public void DrStatusDisp()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (drgimmick != null)
        {
            isclearflag = drgimmick.GetComponent<CircleArrowManager>().clearflag;
            Debug.Log(isclearflag);
            if (isclearflag)
            {
                doorSc.hacked = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == DoorObj)
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


                buttonpos.anchoredPosition = new Vector3(700, -230, 0);
                bc = buttonObj.GetComponent<DrButtonController>();


            }
            else //Hackし終わった後の処理
            {
                // UI表示
                GameObject hackdr = Instantiate(DrHackImage, canvasTrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -200, 0);

                buttonhackObj = Instantiate(DrHackButtonPre, canvasTrans);
                RectTransform buttonhackpos = buttonhackObj.GetComponent<RectTransform>();
                buttonhackpos.anchoredPosition = new Vector3(700, -230, 0);
             }
        }
        if (buttonObj != null && buttonObj.GetComponent<DrButtonController>().drbuttonclick)
        {
            drgimmick = buttonObj.GetComponent<DrButtonController>().gimmickObj;
        }
        if (buttonhackObj != null && buttonhackObj.GetComponent<DrHackButton>().buttonClick)
        {
            doorSc.DoorOpen();
        }
        else if (buttonhackObj != null && !buttonhackObj.GetComponent<DrHackButton>().buttonClick) 
        {
            Debug.Log("wara");
            doorSc.DoorClose();
        }

    }
}
