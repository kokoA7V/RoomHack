using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform startPos, cornerPos1, cornerPos2, goalPos;

    public float speed = 0.5f;

    public bool startFlg, corner1Flg, corner2Flg, laserFlg, enemyFlg;

    public StageManager sm;

    void Start()
    {
        //初期位置移動
        this.transform.position = startPos.position;

        //フラグリセット
        startFlg = false;
        corner1Flg = false;
        corner2Flg = false;
        laserFlg = false;
        enemyFlg = false;
    }

    void Update()
    {
        if (sm.gameClearFlg || sm.gameOverFlg) return;

        //初期位置からコーナー1まで移動
        if (startFlg)
        {
            startFlg = false;
            StartCoroutine(Move(cornerPos1));
        }

        //コーナー1からコーナー2まで移動
        if (corner1Flg && laserFlg)
        {
            corner1Flg = false;
            StartCoroutine(Move(cornerPos2));
        }

        //コーナー2からゴールまで移動
        if (corner2Flg && enemyFlg)
        {
            corner2Flg = false;
            StartCoroutine(Move(goalPos));
        }

        //コーナー1到着
        if (this.transform.position == cornerPos1.position)
        {
            corner1Flg = true;
        }

        //コーナー2到着
        if(this.transform.position == cornerPos2.position)
        {
            corner2Flg = true;
        }

        //ゲームクリア
        if(this.transform.position == goalPos.position)
        {
            sm.gameClearFlg = true;
        }
    }

    IEnumerator Move(Transform corner)
    {
        // ターゲットまでの距離を計算する
        float distance = Vector3.Distance(transform.position, corner.position);

        // ターゲットまで直線的に移動する
        while (transform.position != corner.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, corner.position, Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "blast")
        {
            sm.gameOverFlg = true;
            Destroy(collision.gameObject);
        }
    }
}
