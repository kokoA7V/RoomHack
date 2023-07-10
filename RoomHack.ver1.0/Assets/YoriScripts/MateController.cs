using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateController : MonoBehaviour
{
    // 情報取得
    UnitCore mateCore;

    [SerializeField, Header("行動番号")]
    public int stateNo = 0;      // 行動番号
    [SerializeField, Header("メソッド用汎用番号")]
    public int methodNo = 0;   // メソッド用汎用番号

    TargetPoint tagetPnt;

    // デリゲード
    // 関数を型にするためのもの
    private delegate void ActFunc();

    // 関数の配列
    private ActFunc[] actFuncTbl;

    private float moveSpd;
    private float pow;

    public LayerMask ltest;


    enum State
    {
        Wait,
        Shot,
        Move,
        Num
    }
    void Start()
    {
        mateCore = GetComponent<UnitCore>();
        moveSpd = mateCore.moveSpd;
        mateCore.dmgLayer = 1;
        actFuncTbl = new ActFunc[(int)State.Num];
        actFuncTbl[(int)State.Wait] = ActWait;
        actFuncTbl[(int)State.Shot] = ActShot;
        actFuncTbl[(int)State.Move] = ActMove;

        stateNo = (int)State.Wait;
    }

    // Update is called once per frame
    void Update()
    {

        actFuncTbl[stateNo]();
        Debug.Log("ugoiteru");
    }
    private void ActWait()
    {

    }
    private void ActShot()
    {
        mateCore.Shot(mateCore.dmgLayer, pow);
    }
    private void ActMove()
    {
        mateCore.UnitMove(moveSpd);
    }

    // いずれ別のクラスにするそれまではここ

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("atattayo");
        // ターゲットポイントがついてるかどうか
        tagetPnt = collision.gameObject.GetComponent<TargetPoint>();
        // ついてないならそのまま返す
        if (tagetPnt == null)
        {
            //Debug.Log("ついてないよ");
            return;
        }
        // ついてるならレイを飛ばす
        else
        {
            //Debug.Log("tuiteruyo");

            // Rayを生成
            Vector3 origin = this.gameObject.transform.position;
            Vector3 diredtion = collision.gameObject.transform.position - origin;
            diredtion = diredtion.normalized;
            Ray ray = new Ray(origin, diredtion * 10);

            // Rayを表示
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            float maxDistance = 10;
            LayerMask layerMask = LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)); 
            // 何か当たったら名前を返す
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction * 10,maxDistance);
            foreach (RaycastHit2D hits in hit )
            {
                if (hits.collider!=null)
                {
                    Debug.Log("Hit" + hits.collider.gameObject.name);
                }
            }
            //if (hit)
            //{
            //    Debug.Log("間に何もないよ");
            //    string name = hit.collider.gameObject.name; // 衝突した相手オブジェクトの名前を取得
            //    Debug.Log(name); // コンソールに表示
            //}
            //else
            //{
            //    Debug.Log("何もないよ");
            //}
        }
    }
}
