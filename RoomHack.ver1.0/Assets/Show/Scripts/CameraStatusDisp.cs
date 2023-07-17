using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatusDisp : MonoBehaviour,ICameraHackUnit
{
    //Camera��UI�\���X�N���v�g
    public bool CmHacked { get; set; } = true;

    public GameObject CameraObj;

    GameObject buttonobj;
    CmButtonController bc;
    bool unhackCrick = false;
    bool hackCrick = false;


    [SerializeField] GameObject UnHackImage;
    [SerializeField] GameObject HackImage;
    [SerializeField] GameObject CmButtonPre;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CmStatusManager();
    }
    public void CmStatusManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == CameraObj && !CmHacked && !unhackCrick) //�܂�Hack���Ă��Ȃ��B
            {
                Transform canvastrans = Canvas.transform;// SerializeField�Ŏ擾
                GameObject unhackdr = Instantiate(UnHackImage, canvastrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -117, 0);

                buttonobj = Instantiate(CmButtonPre, canvastrans);
                RectTransform buttonpos = buttonobj.GetComponent<RectTransform>();
                buttonpos.anchoredPosition = new Vector3(700, -180, 0);
                bc = buttonobj.GetComponent<CmButtonController>();
                unhackCrick = true;
            }
            else if (hit.collider != null && hit.collider.gameObject == CameraObj && CmHacked && !hackCrick) //Hack���I�������̏���
            {
                Transform canvastrans = Canvas.transform;// SerializeField�Ŏ擾
                GameObject hackdr = Instantiate(HackImage, canvastrans);
                RectTransform hackpos = hackdr.GetComponent<RectTransform>();
                hackpos.anchoredPosition = new Vector3(542, -117, 0);
                hackCrick = true;
            }
            else //��������Hack�����s����������Ƃ�
            {
                unhackCrick = false; //������x�Ē���I�I
            }
        }
    }
}
