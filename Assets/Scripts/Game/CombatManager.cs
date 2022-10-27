using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public List<GameObject> combatants = new List<GameObject>();
    public GameObject currentTurn;
    int i = 0;

    public static CombatManager Instance {get; private set;}

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void InitCombat()
    {
        combatants = new List<GameObject>();
    }

    public void BeginCombat()
    {
        i = 0;
        combatants = combatants.OrderByDescending(combatant => combatant.GetComponent<Stats>().baseAgility).ToList<GameObject>();
        currentTurn = combatants[i];
        PlayerController Player = currentTurn.GetComponent<PlayerController>();
        EnemyController Enemy = currentTurn.GetComponent<EnemyController>();
        if (Player != null) currentTurn.GetComponent<PlayerController>().ChangeState(Player.turnState);
        else Enemy.TakeTurn();
    }

    public void NextTurn()
    {
        if (i < combatants.Count() - 1) i++;
        else i = 0;
        currentTurn = combatants[i];
    }
}
