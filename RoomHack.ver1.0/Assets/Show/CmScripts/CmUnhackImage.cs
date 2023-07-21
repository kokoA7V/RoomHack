using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmUnhackImage : MonoBehaviour
{
    GameObject cmbuttonObj;
    CmButtonController cc;
    // Start is called before the first frame update
    void Start()
    {
        cmbuttonObj = GameObject.Find("CmButton(Clone)");
        cc = cmbuttonObj.GetComponent<CmButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.cmbuttonclick)
        {
            Destroy(gameObject);
        }
    }
}
