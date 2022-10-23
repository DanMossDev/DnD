using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject SpellBook;

    public void OnOpenSpellBook() => SpellBook.SetActive(!SpellBook.activeSelf);
}
