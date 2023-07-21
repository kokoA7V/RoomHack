using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
    public float speed = 1.0f;
    private Text titleText;
    private float time;

    [SerializeField]
    private Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        titleText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        titleText.color = GetAlphaColor(titleText.color);

        if (Input.anyKey) fade.FadeIn(1f, () => SceneManager.LoadScene("LoadScene"));
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);
        return color;
    }
}
