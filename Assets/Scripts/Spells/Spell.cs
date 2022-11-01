using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellSO SpellToCast;
    [HideInInspector] public Vector3 targetPos;
    [HideInInspector] public Stats stats;


    void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * SpellToCast.speed);
            return;
        }

        Collider[] collisions = Physics.OverlapSphere(transform.position, SpellToCast.splashRadius, SpellToCast.targetLayers);
        foreach (Collider collision in collisions)
        {
            Stats collStats = collision.GetComponent<Stats>();

            if (collStats != null) collStats.TakeDamage((int)Mathf.Round(stats.Intelligence * SpellToCast.damageMultiplier));
        }
        Destroy(gameObject);
    }
}
