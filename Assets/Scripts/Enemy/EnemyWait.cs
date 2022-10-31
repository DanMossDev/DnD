using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWait : EnemyState
{
    public override void EnterState(EnemyController context) 
    {
        context.healthBar.enabled = true;
    }
    public override void UpdateState(EnemyController context) 
    {
        
    }
}
