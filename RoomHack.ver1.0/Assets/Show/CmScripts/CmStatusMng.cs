using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmStatusMng : MonoBehaviour
{
    public bool CcHacked = false;
    public GameObject CctvObj;
    GameObject Ccgimmick;
    public cctv CctvSc;
    bool isclearflag;

    GameObject ccbuttonhackObj;
    GameObject buttonObj;
    GameObject cchb;

    CmButtonController cbc;

    Transform canvasTrans;

    [SerializeField] GameObject CcUnHackImage;
    [SerializeField] GameObject CcHackImage;
    [SerializeField] GameObject CcButtonPre;
    [SerializeField] GameObject CcHackButtonPre;
    [SerializeField] GameObject Canvas;
   
    // Start is called before the first frame update
    void Start()
    {
        canvasTrans = Canvas.transform;
        CctvSc = gameObject.GetComponent<cctv>();
    }

    // Update is called once per frame
    void Update()
    {
        CmStatusDisp();
    }
    public void CmStatusDisp()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (Ccgimmick != null)
        {
            isclearflag = Ccgimmick.GetComponent<CircleArrowManager>().clearflag;
            Debug.Log(isclearflag);
            if (isclearflag)
            {
                CctvSc.hacked = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == CctvObj)
        {
            CctvSc = hit.collider.gameObject.GetComponent<cctv>();

            if (!CctvSc.hacked) //まだHackしていない。
            {
                // UI表示
                GameObject unhackdr = Instantiate(CcUnHackImage, canvasTrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -200, 0);

                // ボタン生成
                buttonObj = Instantiate(CcButtonPre, canvasTrans);
                RectTransform buttonpos = buttonObj.GetComponent<RectTransform>();


                buttonpos.anchoredPosition = new Vector3(700, -230, 0);
                cbc = buttonObj.GetComponent<CmButtonController>();


            }
            else //Hackし終わった後の処理
            {
                // UI表示
                GameObject hackdr = Instantiate(CcHackImage, canvasTrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -200, 0);

                ccbuttonhackObj = Instantiate(CcHackButtonPre, canvasTrans);
                RectTransform buttonhackpos = ccbuttonhackObj.GetComponent<RectTransform>();
                buttonhackpos.anchoredPosition = new Vector3(700, -230, 0);
            }
        }
        if (buttonObj != null && buttonObj.GetComponent<CmButtonController>().cmbuttonclick)
        {
            Ccgimmick = buttonObj.GetComponent<CmButtonController>().gimmickObj;
        }

        if (ccbuttonhackObj != null && ccbuttonhackObj.GetComponent<CmHackButton>().ccbuttonClick)
        {
            Debug.Log("SPi");
            CctvSc.Yes();
            ccbuttonhackObj.GetComponent<CmHackButton>().ccbuttonClick = false;
        }
      
    }
}
