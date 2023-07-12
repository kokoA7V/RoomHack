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
        levelText.text = "LEVEL:" + level.ToString();        
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
            timeText.text = "ミッションクリア";
            clearflag = false;
            Debug.Log("クリア");
            Destroy(gameObject, 1.0f); //クリアした後にギミックを消滅処理。by show
        }
        else if (timer <= 0)
        {
            rotationStopFlg = false;
            timeText.text = "ミッション失敗";
            missflag = false;
            Destroy(gameObject, 1.0f);
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
                    //白いラインに入っているときの処理
                    clearCount++;
                }
                else
                {
                    //白いラインに入っていないときの処理
                    timer -= 3;
                }
            }
        }
    }
}
