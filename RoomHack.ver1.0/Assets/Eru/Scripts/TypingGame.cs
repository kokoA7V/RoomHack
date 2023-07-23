using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame : MonoBehaviour
{
    public string[] words;  // �^�C�s���O����P��̃��X�g
    public Color correctColor = Color.green; // �����������̐F
    public Color wrongColor = Color.red;     // �Ԉ���������̐F
    public bool randomOrder = false; // �����_���ɒP����o�����ǂ����̃t���O

    private int currentIndex = 0;   // ���݂̒P��̃C���f�b�N�X
    private TextMesh displayText;   // �e�L�X�g��\������I�u�W�F�N�g��TextMesh�R���|�[�l���g

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
            // �Q�[���I������
            Debug.Log("�Q�[���I���I");
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
            // �P��̍Ō�̕����܂œ��͂��ꂽ�ꍇ
            return;
        }

        if (inputChar == words[currentIndex][displayText.text.Length])
        {
            // ���������������͂��ꂽ�ꍇ
            ChangeCharacterColor(correctColor);
            if (displayText.text.Length + 1 == words[currentIndex].Length)
            {
                // �P��̍Ō�̕����܂Ő��������͂��ꂽ�ꍇ
                currentIndex++;
                DisplayCurrentWord();
            }
        }
        else
        {
            // �Ԉ�������������͂��ꂽ�ꍇ
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
            // �����_���ɒP��̏������V���b�t��
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
