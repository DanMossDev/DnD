using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float castRange = 10;
    public float splashRange = 1;
    public abstract void Cast(Stats stats, Vector3 target, Transform startPos);
}
