using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float SplashRadius = 5;
    [SerializeField] float damageMultiplier = 1.5f;
    [HideInInspector] public Stats stats;
    [HideInInspector] public Vector3 targetPos;
    int damage;
    Vector3 entryPos;
    float lerp = 0;
    void Start()
    {
        entryPos = transform.position;
        damage = (int)(stats.Intelligence * damageMultiplier);
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
