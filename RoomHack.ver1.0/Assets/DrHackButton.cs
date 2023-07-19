using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrHackButton : MonoBehaviour
{
    public bool buttonClick = false;
    bool count = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OnClick()
    {
        count = false;
        if(!count)
        {
            if(buttonClick)
            {
                buttonClick = false;
                count = true;
            }
            else
            {
                buttonClick = true;
                count = true;
            }
           
        }
        Debug.Log(buttonClick);
    }
}
