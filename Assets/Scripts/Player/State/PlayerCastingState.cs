using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastingState : PlayerState
{
    float castRange;
    float splashRange;
    public override void EnterState(PlayerController context)
    {
        castRange = context.preppedSpell.castRange;
        splashRange = context.preppedSpell.splashRange;
    }
    public override void UpdateState(PlayerController context) 
    {
        //Render something to show the range of the spell and the splash range?
        //If click, cast the spell at the target position

        if (Input.GetMouseButtonDown(0)) 
        {
            context.preppedSpell.Cast(context.stats, Utils.CalculateMousePosition(), context.transform);
            if (GameController.Instance.currentState == GameController.Instance.baseState) context.ChangeState(context.idleState);
            else context.ChangeState(context.waitState);
        }
    }
}
