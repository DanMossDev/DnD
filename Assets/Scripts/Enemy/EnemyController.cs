using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum Options
    {
        Aggresive,
        Ranged
    }
    public bool isMoving = false;
    public bool isEnemy = false;
    public float aggroRange = 10;
    public Vector3[] patrolPoints;
    public Ability[] spells;
    [SerializeField] Options option;
    [SerializeField] LayerMask allyLayer;

    [HideInInspector] public Canvas healthBar;

    public EnemyState currentState;
    [HideInInspector] public EnemyIdle idleState = new EnemyIdle();
    [HideInInspector] public EnemyAgro agroState = new EnemyAgro();
    [HideInInspector] public EnemyRanged rangedState = new EnemyRanged();
    [HideInInspector] public EnemyFlee fleeState = new EnemyFlee();
    [HideInInspector] public EnemyWait waitState = new EnemyWait();
    [HideInInspector] public EnemyDead deathState = new EnemyDead();

    [HideInInspector] public GameObject Player;
    [HideInInspector] public NavMeshAgent navMesh;
    [HideInInspector] public Stats stats;


    Rigidbody[] ragdollRigidbodies;

    Vector3 startPoint;

    void Awake()
    {
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
        Player = FindObjectOfType<PlayerController>().gameObject;
    }
    void Start()
    {
        startPoint = transform.position;
        healthBar = GetComponentInChildren<Canvas>();
        healthBar.enabled = false;
        navMesh = GetComponent<NavMeshAgent>();
        stats = GetComponent<Stats>();

        ChangeState(idleState);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(EnemyState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void EnterCombat()
    {
        ChangeState(waitState);

        if (GameController.Instance.currentState != GameController.Instance.combatState)
        {
            CombatManager.Instance.InitCombat();
            GameController.Instance.ChangeState(GameController.Instance.combatState);
        }

        CombatManager.Instance.combatants.Add(this.gameObject);
    }

    public void CheckForPlayer()
    {
        if (!isEnemy) return;

        if (Physics.OverlapSphere(transform.position, aggroRange, LayerMask.GetMask("Player")).Length != 0) //checks if the player is within aggro range
        {
            Collider[] nearbyAllies = Physics.OverlapSphere(transform.position, aggroRange * 2, allyLayer); //Checks for nearby game objects on the same layer in their aggro range doubled
            foreach (Collider ally in nearbyAllies)
            {
                ally.gameObject.GetComponent<EnemyController>().EnterCombat();
            }
        }
    }


    public void TakeTurn()
    {
        switch (option)
        {
            case Options.Aggresive:
                ChangeState(agroState);
                break;
            case Options.Ranged:
                ChangeState(rangedState);
                break;
        }
    }

    public void EndTurn()
    {
        ChangeState(waitState);
        StartCoroutine(Utils.DelayEndTurn());
    }

    public void ToggleRagdoll(bool isAlive)
    {
        foreach (Rigidbody rigidbody in ragdollRigidbodies) rigidbody.isKinematic = isAlive;
    }
}
