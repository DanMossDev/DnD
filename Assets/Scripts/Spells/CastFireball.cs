using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : Ability
{
    GameObject fireballInstance;

    public override void Cast(Stats stats, Vector3 target, Transform startPos) 
    {
        fireballInstance = Instantiate(PrefabHolder.Instance.fireball, startPos);
        fireballInstance.GetComponent<Fireball>().targetPos = target;
        fireballInstance.GetComponent<Fireball>().stats = stats;
    }
}
