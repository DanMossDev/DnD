using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EnemyState
{
    public override void EnterState(EnemyController context) 
    {
        context.healthBar.enabled = false;
        context.ToggleRagdoll(false);
    }
    public override void UpdateState(EnemyController context) 
    {
        
    }
}
