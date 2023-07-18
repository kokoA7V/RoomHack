using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmStatusMng : MonoBehaviour, ICameraHackUnit
{
    //Camera��UI�\���X�N���v�g
    public bool CmHacked { get; set; } = false; //interface�Ōp���B

    public GameObject CameraObj;

    GameObject buttonobj;
    CmButtonController bc;

    bool cmunhack = false;
    bool cmhack = false;


    [SerializeField] GameObject CmUnHackImage;
    [SerializeField] GameObject CmHackImage;
    [SerializeField] GameObject CmButtonPre;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CmStatusDisp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == CameraObj && !CmHacked && !cmunhack) //�܂�Hack���Ă��Ȃ��B
            {
                Transform canvastrans = Canvas.transform;// SerializeField�Ŏ擾
                GameObject unhackdr = Instantiate(CmUnHackImage, canvastrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -117, 0);

                buttonobj = Instantiate(CmButtonPre, canvastrans);
                RectTransform buttonpos = buttonobj.GetComponent<RectTransform>();
                buttonpos.anchoredPosition = new Vector3(700, -180, 0);
                bc = buttonobj.GetComponent<CmButtonController>();
                cmunhack = true;
            }
            else if (hit.collider != null && hit.collider.gameObject == CameraObj && CmHacked && !cmhack) //Hack���I�������̏���
            {
                Transform canvastrans = Canvas.transform;// SerializeField�Ŏ擾
                GameObject hackdr = Instantiate(CmHackImage, canvastrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -117, 0);
                cmhack = true;
            }
            else //��������Hack�����s����������Ƃ�
            {
                cmunhack = false; //������x�Ē���I�I
            }
        }
    }
}
