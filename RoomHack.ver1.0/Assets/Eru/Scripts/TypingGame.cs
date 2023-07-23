using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame : MonoBehaviour
{
    public string[] words;  // タイピングする単語のリスト
    public Color correctColor = Color.green; // 正しい文字の色
    public Color wrongColor = Color.red;     // 間違った文字の色
    public bool randomOrder = false; // ランダムに単語を出すかどうかのフラグ

    private int currentIndex = 0;   // 現在の単語のインデックス
    private TextMesh displayText;   // テキストを表示するオブジェクトのTextMeshコンポーネント

    void Start()
    {
        displayText = GetComponent<TextMesh>();
        ShuffleWordsIfRequired();
        DisplayCurrentWord();
    }

    void Update()
    {
        if (currentIndex >= words.Length)
        {
            // ゲーム終了処理
            Debug.Log("ゲーム終了！");
            return;
        }

        if (Input.anyKeyDown)
        {
            char inputChar = Input.inputString.Length > 0 ? Input.inputString[0] : '\0';
            if (inputChar != '\0')
            {
                CheckInput(inputChar);
            }
        }
    }

    void CheckInput(char inputChar)
    {
        if (currentIndex >= words.Length) return;

        if (displayText.text.Length >= words[currentIndex].Length)
        {
            // 単語の最後の文字まで入力された場合
            return;
        }

        if (inputChar == words[currentIndex][displayText.text.Length])
        {
            // 正しい文字が入力された場合
            ChangeCharacterColor(correctColor);
            if (displayText.text.Length + 1 == words[currentIndex].Length)
            {
                // 単語の最後の文字まで正しく入力された場合
                currentIndex++;
                DisplayCurrentWord();
            }
        }
        else
        {
            // 間違った文字が入力された場合
            ChangeCharacterColor(wrongColor);
        }
    }

    void ChangeCharacterColor(Color color)
    {
        displayText.color = color;
    }

    void DisplayCurrentWord()
    {
        if (currentIndex < words.Length)
        {
            displayText.text = words[currentIndex];
            ChangeCharacterColor(Color.white);
        }
    }

    void ShuffleWordsIfRequired()
    {
        if (randomOrder)
        {
            // ランダムに単語の順序をシャッフル
            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = Random.Range(i, words.Length);
                string temp = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = temp;
            }
        }
    }
}
