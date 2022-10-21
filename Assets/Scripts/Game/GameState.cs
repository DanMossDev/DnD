using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public abstract void EnterState(GameController context);
    public abstract void UpdateState(GameController context);
}