using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrUnHackImage : MonoBehaviour
{
    GameObject buttonObj;
    DrButtonController bc;
    // Start is called before the first frame update
    void Start()
    {
        buttonObj = GameObject.Find("Button(Clone)");
        bc = buttonObj.GetComponent<DrButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.drbuttonclick)
        {
            Destroy(gameObject);
        }
    }
}
