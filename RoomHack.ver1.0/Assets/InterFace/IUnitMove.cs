using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitMove 
{
    public float moveSpd { get; set; }

    public void UnitMove(float spd);
}
