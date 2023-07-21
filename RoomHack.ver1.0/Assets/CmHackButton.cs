using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmHackButton : MonoBehaviour
{
    public bool count = false;
    public bool ccbuttonClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        count = false;
        if (!count)
        {
            if (ccbuttonClick)
            {
                ccbuttonClick = false;
                count = true;
            }
            else
            {
                ccbuttonClick = true;
                count = true;
            }
        }
    }
}
