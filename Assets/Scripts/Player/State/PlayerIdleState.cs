using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public override void EnterState(PlayerController context) {}
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButton(1)) context.ChangeState(context.moveState);
    }
    public override void LeaveState(PlayerController context) {}
}
