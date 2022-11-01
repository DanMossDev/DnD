using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : EnemyState
{
    Spell currentSpell;
    Vector3 previousPosition;
    float remainingDistance;
    public override void EnterState(EnemyController context) 
    {
        previousPosition = context.transform.position;
        remainingDistance = context.stats.Agility;
        currentSpell = context.spells[Random.Range(0, context.spells.Length)];

        if (Vector3.Distance(context.Player.transform.position, context.transform.position) > context.navMesh.stoppingDistance) context.navMesh.destination = context.Player.transform.position;
    }
    public override void UpdateState(EnemyController context) 
    {
        remainingDistance -= Vector3.Distance(previousPosition, context.transform.position);
        previousPosition = context.transform.position;

        if (remainingDistance <= 0) {
            context.navMesh.destination = context.transform.position;
            remainingDistance = 0;
        }
        if (Vector3.Distance(context.navMesh.destination, context.transform.position) < context.navMesh.stoppingDistance) Attack(context);
    }

    void Attack(EnemyController context)
    {
        Vector3 target;
        float distToPlayer = Vector3.Distance(context.Player.transform.position, context.transform.position);
        if (distToPlayer <= context.stats.Perception * 2)
        {
            target = context.Player.transform.position;
            while (Vector3.Distance(context.transform.position, target) <= currentSpell.SpellToCast.splashRadius + 1)
            {
                target += (target - context.transform.position) * 0.1f;
            }
            context.Cast(target, currentSpell);
        }

        context.EndTurn();
    }
}
