using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCombat : GameState
{
    public delegate void EnterCombat();
    public static event EnterCombat OnEnterCombat;
    public override void EnterState(GameController context) 
    {
        OnEnterCombat();
    }
    public override void UpdateState(GameController context) {}
}