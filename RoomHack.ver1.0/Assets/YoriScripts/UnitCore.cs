using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCore : MonoBehaviour, IUnitMove, IUnitShot, IUnitHack, IUnitDamage
{
    public float maxHP { get; set; }
    public float nowHP { get; set; }
    public int dmgLayer{ get; set; }

    public float moveSpd { get; set; } = 0.3f;


    public bool hacked { get; set; } = false;
    
    public void HitDmg() { }
    public void Die() { }
    public void Shot(int layer, float pow)
    {
        
    }

    public void StatusDisp()
    {

    }

    public void Move(float moveSpd,GameObject unit)
    {
        GetComponent<Move>().UnitMove(moveSpd,unit);
    }

}
