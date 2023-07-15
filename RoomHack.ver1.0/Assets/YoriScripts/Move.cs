using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 movePos;
    [SerializeField] 
    private float limitSpeed;

    Rigidbody2D unitRb;
    private void Start()
    {
        unitRb = GetComponent<Rigidbody2D>();
    }
    public void UnitMove(float _moveSpd,GameObject _unit)
    {
        movePos = _unit.transform.position - this.transform.position;
        unitRb.AddForce(movePos.normalized * _moveSpd);

        float speedXTemp = Mathf.Clamp(unitRb.velocity.x, -limitSpeed, limitSpeed);�@//X�����̑��x�𐧌�
        float speedYTemp = Mathf.Clamp(unitRb.velocity.y, -limitSpeed, limitSpeed);  //Y�����̑��x�𐧌�
        unitRb.velocity = new Vector3(speedXTemp, speedYTemp);�@�@�@�@�@�@�@�@�@�@�@//���ۂɐ��������l����
    }
    
}
