using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : MonoBehaviour
{
    public GameObject fireball;

    public static PrefabHolder Instance {get; private set;}

    void Awake() 
    {
        if (Instance != null && Instance != this)  Destroy(this); 
        else Instance = this; 
    }
}
