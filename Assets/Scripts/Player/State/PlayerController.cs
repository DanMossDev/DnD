using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    [HideInInspector] public PlayerIdleState idleState = new PlayerIdleState();
    [HideInInspector] public PlayerMoveState moveState = new PlayerMoveState();
    [HideInInspector] public PlayerStateCombatWait waitState = new PlayerStateCombatWait();
    [HideInInspector] public PlayerStateCombatTurn turnState = new PlayerStateCombatTurn();
    [HideInInspector] public PlayerCastingState castState = new PlayerCastingState();
    [HideInInspector] public NavMeshAgent navMesh;
    [HideInInspector] public Ability preppedSpell;
    [HideInInspector] public Stats stats;

    public static PlayerController Instance {get; private set;}

    void Awake() 
    {
        if (Instance != null && Instance != this)  Destroy(this); 
        else Instance = this; 
    }

    void OnEnable()
    {
        GameStateCombat.OnEnterCombat += OnEnterCombat;
    }
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        stats = GetComponent<Stats>();
        currentState = turnState;
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
    void OnEnterCombat()
    {
        ChangeState(waitState);
    }
}
