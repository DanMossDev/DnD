using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public List<GameObject> combatants = new List<GameObject>();

    public static CombatManager Instance {get; private set;}

    GameObject currentTurn;

    void OnAwake()
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
        combatants = combatants.OrderBy(combatant => combatant.GetComponent<Stats>().baseAgility).ToList<GameObject>();
        currentTurn = combatants[0];
        PlayerController Player = currentTurn.GetComponent<PlayerController>();
        EnemyController Enemy = currentTurn.GetComponent<EnemyController>();
        if (Player != null) currentTurn.GetComponent<PlayerController>().ChangeState(Player.turnState);
    }

    public void NextTurn()
    {

    }
}
