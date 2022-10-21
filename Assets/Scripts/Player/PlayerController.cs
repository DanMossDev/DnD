using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    PlayerState currentState;
    [HideInInspector] public PlayerIdleState idleState = new PlayerIdleState();
    [HideInInspector] public PlayerMoveState moveState = new PlayerMoveState();
    [HideInInspector] public PlayerStateCombatWait waitState = new PlayerStateCombatWait();
    [HideInInspector] public PlayerStateCombatTurn turnState = new PlayerStateCombatTurn();
    [HideInInspector] public NavMeshAgent navMesh;


    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(PlayerState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
