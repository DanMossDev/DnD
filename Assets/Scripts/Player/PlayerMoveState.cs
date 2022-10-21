using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    Vector3 target;
   public override void EnterState(PlayerController context) 
   {
        target = CalculateTarget();
        if (target == Vector3.negativeInfinity) context.ChangeState(context.idleState);
   }
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButton(1)) 
        {
            Vector3 temp = CalculateTarget();
            if (temp != Vector3.negativeInfinity) target = temp;
        }

        context.navMesh.destination = target;

        if (context.navMesh.remainingDistance <= Mathf.Epsilon) context.ChangeState(context.idleState);
    }

    Vector3 CalculateTarget()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.negativeInfinity;
    }
}
