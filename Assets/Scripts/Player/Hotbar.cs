using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    [SerializeField] SpellBook playerSpellBook;
    [SerializeField] Button[] spellButtons;

    void Start()
    {
        spellButtons[0].onClick.AddListener(delegate{PrepSpell(0);});
    }

    void PrepSpell(int i)
    {
        PlayerController.Instance.preppedSpell = playerSpellBook.Spells[i];
        PlayerController.Instance.ChangeState(PlayerController.Instance.castState);
    }
}
