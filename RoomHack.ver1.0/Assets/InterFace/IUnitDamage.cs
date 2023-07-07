using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitDamage
{
    public float maxHP{ get; set; }
    public float nowHP{ get; set; }
    public int dmgLayer { get; set; }
    public void HitDmg();
    public void Die();
}
