using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmButtonController : MonoBehaviour
{
    public GameObject DialPre;
    GameObject instantiate;
    public bool cmbuttonclick = false;




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
        GameObject obj = Instantiate(DialPre, ver, Quaternion.identity); //Door用のギミック
        cmbuttonclick = true;
        Destroy(this.gameObject);
    }
}
