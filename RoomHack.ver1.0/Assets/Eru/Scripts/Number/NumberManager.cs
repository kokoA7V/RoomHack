using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public int level = 3;
    public int oneSetTime = 10;

    private int[] num = new int[9];

    private int timer;
    private int ans;
    private int clear;

    private float time = 0;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text[] text;

    [SerializeField]
    private GameObject[] gameObjects;

    void Start()
    {
        timer = oneSetTime * level;
        levelText.text = "LEVEL:" + level.ToString();
        StartNumber();
        clear = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (ans == 10)
        {
            clear++;
            if (clear >= level)
            {
                timeText.text = "ミッションクリア";
                return;
            }
            else
            {
                StartNumber();
            }
        }
        else if(timer <= 0)
        {
            timeText.text = "ミッション失敗";
            return;
        }

        if(time > 1f)
        {
            time = 0;
            timer--;
            timeText.text = timer.ToString();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            for (int i = 0; i < 9; i++)
            {
                if (hit.collider != null && hit.collider.gameObject == gameObjects[i])
                {
                    if (num[i] == ans)
                    {
                        gameObjects[i].GetComponent<SpriteRenderer>().color = Color.red;
                        ans++;
                    }
                    else if(num[i] > ans)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            gameObjects[j].GetComponent<SpriteRenderer>().color = Color.gray;
                        }
                        ans = 1;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void StartNumber()
    {
        //ランダム
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> randomizedNumbers = RandomizeList(numbers);

        int i = 0;
        foreach (int number in randomizedNumbers)
        {
            num[i] = number;
            text[i].text = number.ToString();
            gameObjects[i].GetComponent<SpriteRenderer>().color = Color.gray;
            i++;
        }

        timeText.text = timer.ToString();

        ans = 1;
    }

    /// <summary>
    /// ランダム
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    List<T> RandomizeList<T>(List<T> list)
    {
        List<T> randomizedList = new List<T>(list);

        int n = randomizedList.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = randomizedList[k];
            randomizedList[k] = randomizedList[n];
            randomizedList[n] = value;
        }

        return randomizedList;
    }
}
