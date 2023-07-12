using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrickManager : MonoBehaviour
{
    public GameObject Door;
    public GameObject ButtonPre;
    public GameObject HackTitlePre;
    public GameObject HackedTextPre;
    public GameObject HackTextPre;

    ButtonController bc;
    CircleArrowManager CirMng;

    [SerializeField] GameObject Hacktext;
    [SerializeField] GameObject ButtonText;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトクリック取得
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == Door) 
            {
                Transform canvasTrans = Canvas.transform;// SerializeFieldで取得
                GameObject door = Instantiate(HackTitlePre, canvasTrans);
                GameObject obj = Instantiate(ButtonPre, canvasTrans);
                bc = obj.GetComponent<ButtonController>();
                RectTransform doorhak = door.GetComponent<RectTransform>();
                RectTransform rect = obj.GetComponent<RectTransform>();
                doorhak.anchoredPosition = new Vector3(542, -117, 0);
                rect.anchoredPosition = new Vector3(784, -180, 0);
            }
        }
    }
}
