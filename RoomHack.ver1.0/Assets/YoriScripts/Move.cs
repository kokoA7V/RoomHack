using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 movePos;
    
    [SerializeField]
    private float limitSpeed;

    private Rigidbody2D unitRb;

    private Vector2 moveDir;

    private float moveCtr = 0;

    private void Start()
    {
        unitRb = GetComponent<Rigidbody2D>();
    }

    public void UnitMove(float _moveSpd,GameObject _unit)
    {
        movePos = _unit.transform.position - this.transform.position;
        moveDir = movePos.normalized;

        moveCtr += Time.deltaTime;
      
        unitRb.AddForce(moveDir * _moveSpd);

        // �͂̉��������ɐ��ʂ����킹��
        transform.up = movePos.normalized;

        // �X�s�[�h�ɐ�����������
        float speedXTemp = Mathf.Clamp(unitRb.velocity.x, -limitSpeed, limitSpeed);�@//X�����̑��x�𐧌�
        float speedYTemp = Mathf.Clamp(unitRb.velocity.y, -limitSpeed, limitSpeed);  //Y�����̑��x�𐧌�
        unitRb.velocity = new Vector3(speedXTemp, speedYTemp);�@�@�@�@�@�@�@�@�@�@�@//���ۂɐ��������l����
    }
}
