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
        //�����ʒu�ړ�
        this.transform.position = startPos.position;

        //�t���O���Z�b�g
        startFlg = false;
        corner1Flg = false;
        corner2Flg = false;
        laserFlg = false;
        enemyFlg = false;
    }

    void Update()
    {
        if (sm.gameClearFlg || sm.gameOverFlg) return;

        //�����ʒu����R�[�i�[1�܂ňړ�
        if (startFlg)
        {
            startFlg = false;
            StartCoroutine(Move(cornerPos1));
        }

        //�R�[�i�[1����R�[�i�[2�܂ňړ�
        if (corner1Flg && laserFlg)
        {
            corner1Flg = false;
            StartCoroutine(Move(cornerPos2));
        }

        //�R�[�i�[2����S�[���܂ňړ�
        if (corner2Flg && enemyFlg)
        {
            corner2Flg = false;
            StartCoroutine(Move(goalPos));
        }

        //�R�[�i�[1����
        if (this.transform.position == cornerPos1.position)
        {
            corner1Flg = true;
        }

        //�R�[�i�[2����
        if(this.transform.position == cornerPos2.position)
        {
            corner2Flg = true;
        }

        //�Q�[���N���A
        if(this.transform.position == goalPos.position)
        {
            sm.gameClearFlg = true;
        }
    }

    IEnumerator Move(Transform corner)
    {
        // �^�[�Q�b�g�܂ł̋������v�Z����
        float distance = Vector3.Distance(transform.position, corner.position);

        // �^�[�Q�b�g�܂Œ����I�Ɉړ�����
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
