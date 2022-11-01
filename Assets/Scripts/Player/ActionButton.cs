using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ActionButton : MonoBehaviour, IDropHandler
{
    public Spell CurrentSpell;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (CurrentSpell != null) text.text = CurrentSpell.ToString();
    }

    void UpdateSpell(Spell newSpell)
    {
        CurrentSpell = newSpell;
        text.text = CurrentSpell.ToString();
    }

    public void PrepSpell()
    {
        if (PlayerController.Instance.currentState == PlayerController.Instance.waitState) return;
        PlayerController.Instance.preppedSpell = CurrentSpell;
        PlayerController.Instance.ChangeState(PlayerController.Instance.castState);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) UpdateSpell(eventData.pointerDrag.GetComponent<DragDrop>().referenceAbility);
    }
}
