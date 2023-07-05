using UnityEngine;
using UnityEngine.UI;

public class DialManager : MonoBehaviour
{
    [HideInInspector]
    public bool dial1, dial2, dial3, dial4, missFlg;

    public Text timeText;

    public int timerLevel = 15;

    private int timer;
    private float time = 0;

    void Start()
    {
        //�f�[�^������
        dial1 = false;
        dial2 = false;
        dial3 = false;
        dial4 = false;
        missFlg = false;

        timer = timerLevel;
        timeText.text = timer.ToString();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1f)
        {
            time = 0;
            timer--;
            timeText.text = timer.ToString();
        }
        if (dial1 && dial2 && dial3 && dial4)
        {
            timeText.text = "�~�b�V�����N���A";
        }
        else if(timer <= 0)
        {
            timeText.text = "�~�b�V�������s";
            missFlg = true;
            return;
        }
    }
}
