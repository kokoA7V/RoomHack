using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateController : MonoBehaviour
{
    // ���擾
    UnitCore mateCore;

    [SerializeField, Header("�s���ԍ�")]
    public int stateNo = 0;      // �s���ԍ�
    [SerializeField, Header("���\�b�h�p�ėp�ԍ�")]
    public int methodNo = 0;   // ���\�b�h�p�ėp�ԍ�

    TargetPoint tagetPnt;

    // �f���Q�[�h
    // �֐����^�ɂ��邽�߂̂���
    private delegate void ActFunc();

    // �֐��̔z��
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

    // ������ʂ̃N���X�ɂ��邻��܂ł͂���

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("atattayo");
        // �^�[�Q�b�g�|�C���g�����Ă邩�ǂ���
        tagetPnt = collision.gameObject.GetComponent<TargetPoint>();
        // ���ĂȂ��Ȃ炻�̂܂ܕԂ�
        if (tagetPnt == null)
        {
            //Debug.Log("���ĂȂ���");
            return;
        }
        // ���Ă�Ȃ烌�C���΂�
        else
        {
            //Debug.Log("tuiteruyo");

            // Ray�𐶐�
            Vector3 origin = this.gameObject.transform.position;
            Vector3 diredtion = collision.gameObject.transform.position - origin;
            diredtion = diredtion.normalized;
            Ray ray = new Ray(origin, diredtion * 10);

            // Ray��\��
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            float maxDistance = 10;
            LayerMask layerMask = LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)); 
            // �������������疼�O��Ԃ�
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction * 10,maxDistance);
            foreach (RaycastHit2D hits in hit )
            {
                if (hits.collider!=null)
                {
                    if (hits.collider.gameObject.layer != this.gameObject.layer && hits.collider.gameObject.layer == 8)
                    {
                        Debug.Log("Hit :" + hits.collider.gameObject.name);
                    }
                }
            }
            //if (hit)
            //{
            //    Debug.Log("�Ԃɉ����Ȃ���");
            //    string name = hit.collider.gameObject.name; // �Փ˂�������I�u�W�F�N�g�̖��O���擾
            //    Debug.Log(name); // �R���\�[���ɕ\��
            //}
            //else
            //{
            //    Debug.Log("�����Ȃ���");
            //}
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("atattayo");
        // �^�[�Q�b�g�|�C���g�����Ă邩�ǂ���
        tagetPnt = collision.gameObject.GetComponent<TargetPoint>();
        // ���ĂȂ��Ȃ炻�̂܂ܕԂ�
        if (tagetPnt == null)
        {
            //Debug.Log("���ĂȂ���");
            return;
        }
        // ���Ă�Ȃ烌�C���΂�
        else
        {
            //Debug.Log("tuiteruyo");

            // Ray�𐶐�
            Vector3 origin = this.gameObject.transform.position;
            Vector3 diredtion = collision.gameObject.transform.position - origin;
            diredtion = diredtion.normalized;
            Ray ray = new Ray(origin, diredtion * 10);

            // Ray��\��
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            float maxDistance = 10;
            LayerMask layerMask = LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer));
            // �������������疼�O��Ԃ�
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction * 10, maxDistance);
            foreach (RaycastHit2D hits in hit)
            {
                if (hits.collider != null)
                {
                    if (hits.collider.gameObject.layer != this.gameObject.layer && hits.collider.gameObject.layer == 8)
                    {
                        Debug.Log("Hit :" + hits.collider.gameObject.name);
                    }
                }
            }
            //if (hit)
            //{
            //    Debug.Log("�Ԃɉ����Ȃ���");
            //    string name = hit.collider.gameObject.name; // �Փ˂�������I�u�W�F�N�g�̖��O���擾
            //    Debug.Log(name); // �R���\�[���ɕ\��
            //}
            //else
            //{
            //    Debug.Log("�����Ȃ���");
            //}
        }
    }
}
