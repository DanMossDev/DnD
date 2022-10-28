using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int baseStrength = 5; // how hard you hit/how much you can carry?
    public int baseDexterity = 5; // ranged strength?
    public int baseFortitude = 5; // max HP, multiply by 10
    public int baseIntelligence = 5; // spell power
    public int baseAgility = 5; // combat movement
    public int basePerception = 5; // spell and ranged range

    [HideInInspector] public int Strength;
    [HideInInspector] public int Dexterity;
    [HideInInspector] public int Fortitude;
    [HideInInspector] public int Intelligence;
    [HideInInspector] public int Agility;
    [HideInInspector] public int Perception;

    public int MaxHP;

    public int CurrentHP;


    void Awake() 
    {
        UpdateStats();
        CurrentHP = MaxHP;
    }
    void UpdateStats() 
    {
        Strength = baseStrength;
        Dexterity = baseDexterity;
        Fortitude = baseFortitude;
        Intelligence = baseIntelligence;
        Agility = baseAgility;
        Perception = basePerception;

        MaxHP = Fortitude * 10;
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        print(this.name + " " + CurrentHP);
        if (CurrentHP <= 0)
        {
            //Die();
        }
    }
}
