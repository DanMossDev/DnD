using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : EnemyState
{
    public override void EnterState(EnemyController context) 
    {
        Debug.Log("Entering agro state");
    }
    public override void UpdateState(EnemyController context) {}
}
