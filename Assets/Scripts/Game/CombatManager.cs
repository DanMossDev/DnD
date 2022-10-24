using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static List<GameObject> combatants = new List<GameObject>();

    void InitCombat()
    {
        combatants = new List<GameObject>();
    }

    
}
