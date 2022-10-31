using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombatWait : PlayerState
{
    public override void EnterState(PlayerController context)
    {
        context.healthBar.enabled = true;
        context.remainingDistance = context.stats.Agility;
    }
    public override void UpdateState(PlayerController context) 
    {}

    public override void LeaveState(PlayerController context) {}

}
