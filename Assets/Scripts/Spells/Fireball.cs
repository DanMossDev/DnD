using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [HideInInspector] public float SplashRadius;
    [HideInInspector] public float damageMultiplier = 1;
    public Stats stats;
    [HideInInspector] public Vector3 targetPos;
    [HideInInspector] public int damage;
    [HideInInspector] public Vector3 entryPos;
    float lerp = 0;
    void Start()
    {
        entryPos = transform.position;
        damage = (int)(stats.Intelligence * damageMultiplier);
    }

    public void Init(Vector3 target, Stats _stats, float splashRange)
    {
        targetPos = target;
        stats = _stats;
        SplashRadius = splashRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(entryPos, targetPos, lerp);
            lerp += Time.deltaTime;
            return;
        }
        Collider[] collisions = Physics.OverlapSphere(transform.position, SplashRadius);
        foreach (Collider collision in collisions)
        {
            Stats stats = collision.GetComponent<Stats>();

            if (stats != null) stats.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
