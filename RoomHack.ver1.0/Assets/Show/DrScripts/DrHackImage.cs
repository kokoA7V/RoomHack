using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrHackImage : MonoBehaviour
{
    GameObject CameraObj;
    // Start is called before the first frame update
    void Start()
    {
        CameraObj = GameObject.Find("CCTV");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == CameraObj)
            {
                Destroy(gameObject);
            }
        }
    }
}
