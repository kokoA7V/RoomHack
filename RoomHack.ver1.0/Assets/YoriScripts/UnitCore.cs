using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCore : MonoBehaviour, IUnitMove, IUnitShot, IUnitHack, IUnitDamage
{
    public float maxHP { get; set; }
    public float nowHP { get; set; }
    public int dmgLayer{ get; set; }

    public float moveSpd { get; set; } = 1.5f;


    public bool hacked { get; set; } = false;
    
    public void HitDmg() { }
    public void Die() { }
    public void Shot(int layer, int pow,int burst)
    {
        GetComponent<Shot>().UnitShot(layer, pow, burst);
    }

    public void StatusDisp()
    {

    }

    public void Move(float moveSpd,GameObject unit)
    {
        GetComponent<Move>().DemoMove(moveSpd,unit);
    }
}
