using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    public StatData stats;
    [Header("Primary Stats")]
    public int vigor;
    public int strength;
    public int dexterity;
    public int intelligence;
    [Header("Secondary Stats")]
    public bool usingDex; //Temporary until we add weapons
    private int maxHp;
    private int maxMana;
    public int hp;
    public int mana;
    public int damage;
    public int defence;
    public int mdefence;
    //Level up
    private int expNeeded;
    public int level;
    public int exp;

    private void InitializeCharacter() {
        vigor = stats.baseVigor;
        strength = stats.baseVigor;
        dexterity = stats.baseVigor;
        intelligence = stats.baseVigor;
        level = 1;
        exp = 0;
        expNeeded = 10;
        CalculateStats();
    }

    private void CalculateStats() {
        damage = usingDex ? strength : dexterity;
        defence = vigor;
        mdefence = intelligence;
        maxHp = vigor * 10;
        maxMana = intelligence * 10;
    }
}
