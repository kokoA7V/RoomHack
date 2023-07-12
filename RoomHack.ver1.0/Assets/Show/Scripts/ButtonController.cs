using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject CrickArrowPre;
    public GameObject HackTitlePre;
    public bool isbutclick = false;

    [HideInInspector]
    public CircleArrowManager cama;

    CrickManager crMng;

    GameObject instantiate;
    // Start is called before the first frame update
    void Start()
    {
        instantiate = GameObject.Find("InstantieObject");
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void OnClick()
    {
        Vector2 ver = instantiate.transform.position;
        GameObject obj = Instantiate(CrickArrowPre, ver, Quaternion.identity);
        cama = obj.GetComponent<CircleArrowManager>();
        Destroy(this.gameObject);
        isbutclick = true;
    }
}
