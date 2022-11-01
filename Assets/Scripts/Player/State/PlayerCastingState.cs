using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastingState : PlayerState
{
    public override void EnterState(PlayerController context)
    {
    }
    
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(Utils.CalculateMousePosition(), context.transform.position) <= context.stats.Perception * 2) 
        {
            context.Cast(Utils.CalculateMousePosition());
            if (GameController.Instance.currentState == GameController.Instance.baseState) context.ChangeState(context.idleState);
            else context.EndTurn();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            context.ChangeState(context.previousState);
        }
    }

    public override void LeaveState(PlayerController context) 
    {
        context.preppedSpell = null;
    }
}
