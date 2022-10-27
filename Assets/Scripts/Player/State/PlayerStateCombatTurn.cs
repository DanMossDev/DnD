using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombatTurn : PlayerState
{
    Vector3 target;
    float distanceCheck = 0;
    float remainingDistance;
    bool isWalking = false;
    public override void EnterState(PlayerController context)
    {
        remainingDistance = context.stats.Agility;
    }
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButtonDown(1) && remainingDistance > 0) WalkHere(context);
        if (!isWalking) return;

        if (distanceCheck != 0 && context.navMesh.remainingDistance <= distanceCheck) {
            context.navMesh.destination = context.transform.position;
            remainingDistance = 0;
            isWalking = false;
        }
        if (context.navMesh.remainingDistance <= Mathf.Epsilon && remainingDistance > 0) isWalking = false;
    }

    public override void LeaveState(PlayerController context) {}


    void WalkHere(PlayerController context)
    {
        distanceCheck = 0;
        Vector3 temp = Utils.CalculateMousePosition();
        if (temp != Vector3.negativeInfinity) target = temp;

        context.navMesh.destination = target;
        context.StartCoroutine(CombatWalk(context));
    }

    IEnumerator CombatWalk(PlayerController context)
    {
        while (context.navMesh.pathPending) yield return new WaitForEndOfFrame();

        if (context.navMesh.remainingDistance > remainingDistance) distanceCheck = context.navMesh.remainingDistance - remainingDistance;
        else remainingDistance -= context.navMesh.remainingDistance;

        isWalking = true;
    }
}
