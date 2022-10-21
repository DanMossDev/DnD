using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameState currentState;

    [HideInInspector] public GameStateBase baseState = new GameStateBase();
    [HideInInspector] public GameStateCombat combatState = new GameStateCombat();

    private void Start()
    {
        currentState = baseState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}