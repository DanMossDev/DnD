using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBase : GameState
{
    public delegate void LeaveCombat();
    public static event LeaveCombat OnLeaveCombat;
    public override void EnterState(GameController context) 
    {
        OnLeaveCombat();
    }
    public override void UpdateState(GameController context) {}
}