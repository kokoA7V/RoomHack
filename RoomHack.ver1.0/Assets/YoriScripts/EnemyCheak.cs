using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    private RaycastHit2D[] emHit;
    public bool  EnemyCheck()
    {
        // Ray‚ğ¶¬
        Vector3 origin = this.gameObject.transform.position;
        Vector3 diredtion = this.transform.up;
        Ray emCheackray = new Ray(origin, diredtion);

        // Ray‚ğ•\¦
        Debug.DrawRay(emCheackray.origin, emCheackray.direction , Color.blue);

        // ray‚Ì‹——£‚ğ§ŒÀ
        float maxDistance = 0.03f;

        // ©•ªˆÈŠO‚É“–‚½‚é‚æ‚¤‚É‚·‚é
        int layerMask = ~(1 << gameObject.layer);

        // ‰½‚©“–‚½‚Á‚½‚ç–¼‘O‚ğ•Ô‚·
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
