using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    private RaycastHit2D[] emHit;
    public bool  EnemyCheck()
    {
        // Ray�𐶐�
        Vector3 origin = this.gameObject.transform.position;
        Vector3 diredtion = this.transform.up;
        Ray emCheackray = new Ray(origin, diredtion);

        // Ray��\��
        Debug.DrawRay(emCheackray.origin, emCheackray.direction , Color.blue);

        // ray�̋����𐧌�
        float maxDistance = 0.03f;

        // �����ȊO�ɓ�����悤�ɂ���
        int layerMask = ~(1 << gameObject.layer);

        // �������������疼�O��Ԃ�
        emHit = Physics2D.RaycastAll(emCheackray.origin, emCheackray.direction , maxDistance, layerMask);
        foreach (RaycastHit2D emHits in emHit)
        {
            if (emHits.collider != null)
            {
                Debug.Log(emHits.collider.gameObject.name);
                return true;
            }
        }
        return false;
    }
}
