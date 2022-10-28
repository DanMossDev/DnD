using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissile : Ability
{
    GameObject missileInstance;
    Vector3 targetPos;
    Vector3 entryPos;
    float lerp;
    public override void Cast(Stats stats, Vector3 target, Transform startPos) 
    {
        missileInstance = Instantiate(PrefabHolder.Instance.fireball, startPos);
        targetPos = target;
        entryPos = startPos.position;
        lerp = 0;
    }

    void Update()
    {
        if (missileInstance == null) return;
        if (Vector3.Distance(missileInstance.transform.position, targetPos) > 0.1f)
        {
            missileInstance.transform.position = Vector3.Lerp(entryPos, targetPos, lerp);
            lerp += Time.deltaTime;
            return;
        }
        Destroy(missileInstance);
    }
}
