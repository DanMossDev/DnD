using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombatTurn : PlayerState
{
    int movement;
    Vector3 targetPoint;
    public override void EnterState(PlayerController context)
    {
        movement = 4;
    }
    public override void UpdateState(PlayerController context) 
    {
        if (Input.GetMouseButtonDown(1)) ShowOptions();
    }

    void ShowOptions()
    {
        targetPoint = Utils.CalculateMousePosition();
    }

    void Move(PlayerController context)
    {
        context.navMesh.destination = targetPoint;
    }
}
