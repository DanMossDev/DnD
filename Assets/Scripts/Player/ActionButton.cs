using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ActionButton : MonoBehaviour, IDropHandler
{
    public Ability CurrentSpell;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (CurrentSpell != null) text.text = CurrentSpell.ToString();
    }

    void UpdateSpell(Ability newSpell)
    {
        CurrentSpell = newSpell;
        text.text = CurrentSpell.ToString();
    }

    public void PrepSpell()
    {
        PlayerController.Instance.preppedSpell = CurrentSpell;
        PlayerController.Instance.ChangeState(PlayerController.Instance.castState);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) UpdateSpell(eventData.pointerDrag.GetComponent<DragDrop>().referenceAbility);
    }
}