using UnityEngine;
using UnityEngine.UI;

public class CircleArrowManager : MonoBehaviour
{
    [HideInInspector]
    public bool inFlg = false;

    [HideInInspector]
    public bool rotationFlg = false;

    [HideInInspector]
    public bool rotationStopFlg = false;

    [HideInInspector]
    public bool clearflag = true;

    [HideInInspector]
    public bool missflag = true;

    public int level = 5;
    public int oneSetTime = 5;
    public float rotationSpeed = 5.0f;

    public Text levelText, timeText;

    private int timer;
    private float time = 0;

    private int clearCount = 0;

    void Start()
    {
        timer = oneSetTime * level;
        timeText.text = timer.ToString();
    }

    void Update()
    {
        Gimmck();
    }

    public void Gimmck()
    {
        if (level <= clearCount)
        {
            rotationStopFlg = true;
            timeText.text = "-SUCCESS-";
            Debug.Log("SUCCESS");
            Destroy(gameObject, 1.0f); //�N���A������ɃM�~�b�N�����ŏ����Bby show
            clearflag = true;
        }
        else if (timer <= 0)
        {
            rotationStopFlg = false;
            timeText.text = "���s";
            Destroy(gameObject, 1.0f);
            missflag = true;
        }
        else
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                time = 0;
                timer--;
                timeText.text = timer.ToString();
            }

            if (Input.GetMouseButtonDown(0))
            {
                rotationFlg = true;
                if (inFlg)
                {
                    //�������C���ɓ����Ă���Ƃ��̏���
                    clearCount++;
                }
                else
                {
                    //�������C���ɓ����Ă��Ȃ��Ƃ��̏���
                    timer -= 3;
                }
            }
        }
    }
}
