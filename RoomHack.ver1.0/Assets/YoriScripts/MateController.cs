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
    

    enum State
    {
        Wait,
        Shot,
        Move,
        Num
    }
    // Start is called before the first frame update
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
    }
    private void ActWait()
    {

    }
    private void ActShot()
    {
        mateCore.Shot(mateCore.dmgLayer,pow);
    }
    private void ActMove()
    {
        mateCore.UnitMove(moveSpd);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        tagetPnt = other.gameObject.GetComponent<TargetPoint>();
        if ( tagetPnt == null )
        {
            return;
        }
          
    }
}
