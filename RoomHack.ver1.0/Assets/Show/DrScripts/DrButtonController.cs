using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrButtonController : MonoBehaviour
{
    public GameObject CircleArrowPre;
    public GameObject gimmickObj;
    GameObject instantiate;
    public bool drbuttonclick = false;

    
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
        gimmickObj = Instantiate(CircleArrowPre, ver, Quaternion.identity); //Door用のギミック
        drbuttonclick = true;
        Destroy(this.gameObject);
    }
}
