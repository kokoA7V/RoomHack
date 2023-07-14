using UnityEngine;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour
{
    public GameObject gameStartUI;
    public Text text;

    public float fadeDuration = 1f;
    private float fadeTimer;

    public MovePlayer mp;

    private bool fadeFlg = false;

    private void Start()
    {
        gameStartUI.SetActive(true);
        fadeTimer = fadeDuration;
    }

    private void Update()
    {
        fadeTimer -= Time.deltaTime;

        // �t�F�[�h�A�E�g
        Color textColor = text.color;
        textColor.a = fadeTimer / fadeDuration;
        text.color = textColor;

        if (fadeTimer <= 0f && !fadeFlg)
        {
            // �t�F�[�h�A�E�g������������e�L�X�g���\���ɂ���
            fadeFlg = true;
            gameStartUI.SetActive(false);
            mp.startFlg = true;
        }
    }
}
