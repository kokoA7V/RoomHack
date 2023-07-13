using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = this.transform.position;
        pos.y += 0.1f;
        this.transform.position = pos;
    }
}
