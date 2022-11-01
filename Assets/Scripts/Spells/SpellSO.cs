using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellSO : ScriptableObject
{
    public int cooldown = 1;
    public float splashRadius = 0;
    public float damageMultiplier = 1;
    public float speed = 5f;
    public LayerMask targetLayers;
}
