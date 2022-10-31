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
    [HideInInspector] public Canvas healthBar;

    public static PlayerController Instance {get; private set;}

    void Awake() 
    {
        if (Instance != null && Instance != this)  Destroy(this); 
        else Instance = this; 
    }

    void OnEnable()
    {
        GameStateCombat.OnEnterCombat += OnEnterCombat;
        GameStateBase.OnLeaveCombat += OnLeaveCombat;
    }
    void OnDisable() 
    {
        GameStateCombat.OnEnterCombat -= OnEnterCombat;
        GameStateBase.OnLeaveCombat -= OnLeaveCombat;
    }

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        stats = GetComponent<Stats>();
        healthBar = GetComponentInChildren<Canvas>();

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
        currentState.LeaveState(this);
        currentState = state;
        currentState.EnterState(this);
    }
    void OnEnterCombat()
    {
        CombatManager.Instance.combatants.Add(gameObject);
        ChangeState(waitState);
        StartCoroutine(BeginCombat());
    }

    void OnLeaveCombat()
    {
        ChangeState(idleState);
    }

    public void EndTurn()
    {
        ChangeState(waitState);
        CombatManager.Instance.NextTurn();
        //Consider adding a delay here? Maybe elsewhere would be better
    }

    IEnumerator BeginCombat()
    {
        yield return new WaitForSeconds(0.1f);
        CombatManager.Instance.BeginCombat();
    }


    public void GameOver()
    {
        print("You LOSE");
    }
}
