using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrickManager : MonoBehaviour
{
    public GameObject Door;
    public GameObject Button;
    public GameObject CircleArrowPre;

    ButtonController bc;
    CircleArrowManager CirMng;

    bool isCrick = false;

    [SerializeField] GameObject UnHacktext;
    [SerializeField] GameObject Hacktext;
    [SerializeField] GameObject ButtonText;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        bc = Button.GetComponent<ButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトクリック取得
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == Door && !isCrick)
            {
                ButtonText.SetActive(true);
                UnHacktext.SetActive(true);
                isCrick = true;
            }
            if(bc.cama.clearflag == false)
            {
                Hacktext.SetActive(true);
            }
        }
        if (bc.isbutclick == true)
        {
            UnHacktext.SetActive(false);
        }
    }
}