using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : Ability
{
    GameObject fireballInstance;

    void Awake() => splashRange = 5;
    
    public override void Cast(Stats stats, Vector3 target, Transform startPos) 
    {
        fireballInstance = Instantiate(PrefabHolder.Instance.fireball, startPos);
        fireballInstance.GetComponent<Fireball>().Init(target, stats, splashRange);
    }
}
