using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    private RaycastHit2D[] emHit;

    private GameObject pnt;
    public bool EnemyCheck()
    {
        // Rayを生成
        Vector3 origin = this.gameObject.transform.position;
        Vector3 diredtion = this.transform.up;
        Ray emCheackray = new Ray(origin, diredtion);

        // Rayを表示
        Debug.DrawRay(emCheackray.origin, emCheackray.direction , Color.blue);

        // rayの距離を制限
        float maxDistance = 0.7f;

        // 自分以外に当たるようにする
        int layerMask = ~(1 << gameObject.layer);

        // 何か当たったらpntにonjを入れる
        emHit = Physics2D.RaycastAll(emCheackray.origin, emCheackray.direction , maxDistance, layerMask);
        foreach (RaycastHit2D emHits in emHit)
        {
            if (emHits.collider != null)
            {
                Debug.Log(emHits.collider.gameObject.name+"を検知した");
                if (emHits.collider.gameObject.TryGetComponent<IUnitDamage>(out var damageable)) return true ;
                else return false;
                //if (pnt != null)
                //{

                //    //pntに入ってるのと同じだったら
                //    if (pnt == emHits.collider.gameObject)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        pnt = emHits.collider.gameObject;
                //        return true;
                //    }
                //}
                //// 最初はこっちに来る
                //else
                //{
                //    pnt = emHits.collider.gameObject;
                //    return true;
                //}
            }
        }
        return false;
    }
}
