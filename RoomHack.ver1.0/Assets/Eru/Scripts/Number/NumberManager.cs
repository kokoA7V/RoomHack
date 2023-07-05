using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private int[] num = new int[9];

    private int ans;

    [SerializeField]
    private Text[] text;

    [SerializeField]
    private GameObject[] gameObjects;

    void Start()
    {
        //ランダム
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> randomizedNumbers = RandomizeList(numbers);

        int i = 0;
        foreach (int number in randomizedNumbers)
        {
            Debug.Log(number);
            num[i] = number;
            text[i].text = number.ToString();
            i++;
        }

        ans = 1;
    }

    void Update()
    {
        if(ans == 10)
        {
            Debug.Log("ミッションクリア");
            return;
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
