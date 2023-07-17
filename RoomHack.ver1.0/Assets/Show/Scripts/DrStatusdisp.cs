using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrStatusdisp : MonoBehaviour, IDoorHackUnit
{
    //Door��UI�\���X�N���v�g
    public bool DrHacked { get; set; } = true;
    public GameObject DoorObj;
    public GameObject CameraObj;

    GameObject buttonobj;
    DrButtonController bc;

    bool unhackCrick = false;
    bool hackCrick = false;


    [SerializeField] GameObject UnHackImage;
    [SerializeField] GameObject HackImage;
    [SerializeField] GameObject DrButtonPre;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        DrStatusManager();
    }
    public void DrStatusManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == DoorObj && !DrHacked && !unhackCrick) //�܂�Hack���Ă��Ȃ��B
            {
                Transform canvastrans = Canvas.transform;// SerializeField�Ŏ擾
                GameObject unhackdr = Instantiate(UnHackImage, canvastrans);
                RectTransform unhackpos = unhackdr.GetComponent<RectTransform>();
                unhackpos.anchoredPosition = new Vector3(542, -117, 0);

                buttonobj = Instantiate(DrButtonPre, canvastrans);
                RectTransform buttonpos = buttonobj.GetComponent<RectTransform>();
                buttonpos.anchoredPosition = new Vector3(700, -180, 0);
                bc = buttonobj.GetComponent<DrButtonController>();
                unhackCrick = true;
            }
            else if (hit.collider != null && hit.collider.gameObject == DoorObj && DrHacked && !hackCrick) //Hack���I�������̏���
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
