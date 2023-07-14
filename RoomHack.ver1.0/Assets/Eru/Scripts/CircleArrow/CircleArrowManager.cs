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
        levelText.text = "LEVEL:" + level.ToString();
    }

    void Update()
    {
        if (level <= clearCount)
        {
            rotationStopFlg = true;
            timeText.text = "�~�b�V�����N���A";
        }
        else if(timer <= 0)
        {
            rotationStopFlg = true;
            timeText.text = "�~�b�V�������s";
        }
        else
        {
            time += Time.deltaTime;
            if(time >= 1f)
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
