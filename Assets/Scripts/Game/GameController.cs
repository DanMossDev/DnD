using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public GameState currentState;

    [HideInInspector] public GameStateBase baseState = new GameStateBase();
    [HideInInspector] public GameStateCombat combatState = new GameStateCombat();

    public static GameController Instance {get; private set;}
    void Awake() 
    {
        if (Instance != null && Instance != this)  Destroy(this); 
        else Instance = this; 
    }

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