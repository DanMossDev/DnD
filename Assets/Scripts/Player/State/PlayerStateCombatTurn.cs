using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombatTurn : PlayerState
{
    Vector3 target;
    Vector3 previousPosition;
    bool isWalking = false;
    public override void EnterState(PlayerController context)
    {
    }
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButtonDown(1) && context.remainingDistance > 0) WalkHere(context);
        if (!isWalking) return;

        context.remainingDistance -= Vector3.Distance(previousPosition, context.transform.position);
        previousPosition = context.transform.position;

        if (context.remainingDistance <= 0) {
            context.navMesh.destination = context.transform.position;
            context.remainingDistance = 0;
            isWalking = false;
        }
        if (context.navMesh.remainingDistance <= Mathf.Epsilon && context.remainingDistance > 0) isWalking = false;
    }

    public override void LeaveState(PlayerController context) {}


    void WalkHere(PlayerController context)
    {
        Vector3 temp = Utils.CalculateMousePosition();
        if (temp != Vector3.negativeInfinity) target = temp;

        context.navMesh.destination = target;
        isWalking = true;
    }
}
