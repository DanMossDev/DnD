using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [System.NonSerialized] public float splashRange = 0;

    public abstract void Cast(Stats stats, Vector3 target, Transform startPos);
}
