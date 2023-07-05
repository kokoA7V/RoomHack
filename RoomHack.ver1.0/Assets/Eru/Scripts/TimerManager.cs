using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text text;

    public StageManager sm;

    private float time, timer;

    void Start()
    {
        time = 0;
        timer = 100;
        text.text = "�c�莞�ԁF" + timer.ToString();
    }

    void Update()
    {
        if (sm.gameClearFlg) return;

        time += Time.deltaTime;

        if(time >= 1f)
        {
            time = 0;
            timer--;
            text.text = "�c�莞�ԁF" + timer.ToString();
        }

        if(timer <= 0f)
        {
            text.enabled = false;
            sm.gameOverFlg = true;
        }
    }
}
