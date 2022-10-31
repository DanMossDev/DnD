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
        //Render something to show the range of the spell and the splash range?
        //If click, cast the spell at the target position

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(Utils.CalculateMousePosition(), context.transform.position) <= context.stats.Perception * 2) 
        {
            context.preppedSpell.Cast(context.stats, Utils.CalculateMousePosition(), context.transform);
            if (GameController.Instance.currentState == GameController.Instance.baseState) context.ChangeState(context.idleState);
            else {
                context.EndTurn();
            }
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
