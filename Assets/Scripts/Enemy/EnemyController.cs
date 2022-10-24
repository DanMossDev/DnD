using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum Options
    {
        Aggresive,
        Ranged
    }
    public bool isMoving = false;
    public Vector3[] patrolPoints;
    public Ability[] spells;
    [SerializeField] Options option;

    EnemyState currentState;
    [HideInInspector] public EnemyIdle idleState = new EnemyIdle();
    [HideInInspector] public EnemyAgro agroState = new EnemyAgro();
    [HideInInspector] public EnemyRanged rangedState = new EnemyRanged();
    [HideInInspector] public EnemyFlee fleeState = new EnemyFlee();


    Vector3 startPoint;
    void Start()
    {
        startPoint = transform.position;

        ChangeState(idleState);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    void ChangeState(EnemyState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void EnterCombat()
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
}
