using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    GameObject fireballInstance;
    Vector3 targetPos;
    Vector3 entryPos;
    float lerp;
    public override void Cast(Stats stats, Vector3 target, Transform startPos) 
    {
        print("Hello");
        fireballInstance = Instantiate(PrefabHolder.Instance.fireball, startPos);
        targetPos = target;
        entryPos = startPos.position;
        lerp = 0;
    }

    void Update()
    {
        if (fireballInstance == null) return;
        if (Vector3.Distance(fireballInstance.transform.position, targetPos) > 0.1f)
        {
            fireballInstance.transform.position = Vector3.Lerp(entryPos, targetPos, lerp);
            lerp += Time.deltaTime;
            return;
        }
        Destroy(fireballInstance);
    }
}
