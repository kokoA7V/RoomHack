using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrStatusManager: MonoBehaviour, IDoorHackUnit
{
    //DoorのUI表示スクリプト
    public bool DrHacked { get; set; } = false;
    public GameObject DoorObj;

    GameObject buttonobj;
    DrButtonController bc;

    bool unhackCrick = false;
    bool hackCrick = false;


    [SerializeField] GameObject DrUnhackImage;
    [SerializeField] GameObject DrHackImage;
    [SerializeField] GameObject DrButtonPre;
    [SerializeField] GameObject Canvas;

    void Start()
    {
       
    }
    void Update()
    {
        DrStatusDisp();
    }
    public void DrStatusDisp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == DoorObj && !DrHacked && !unhackCrick) //まだHackしていない。
            {
                Transform canvastrans = Canvas.transform;// SerializeFieldで取得
                GameObject unhackdr = Instantiate(DrUnhackImage, canvastrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -117, 0);

                buttonobj = Instantiate(DrButtonPre, canvastrans);
                RectTransform buttonpos = buttonobj.GetComponent<RectTransform>();
                buttonpos.anchoredPosition = new Vector3(700, -180, 0);
                bc = buttonobj.GetComponent<DrButtonController>();
                unhackCrick = true;
            }
            else if (hit.collider != null && hit.collider.gameObject == DoorObj && DrHacked && !hackCrick) //Hackし終わった後の処理
            {
                Transform canvastrans = Canvas.transform;// SerializeFieldで取得
                GameObject hackdr = Instantiate(DrHackImage, canvastrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -117, 0);
                hackCrick = true;
            }
            else //そもそもHackが失敗しちゃったとき
            {
                unhackCrick = false; //もう一度再挑戦！！
            }
        }
    }
}
