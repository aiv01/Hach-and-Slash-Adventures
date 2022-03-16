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
    public int MaxHp { get { return maxHp; } }
    private int maxMana;
    public int MaxMana { get { return maxMana; } }
    public int hp;
    public int mana;
    public int damage;
    public int defence;
    public int mdefence;
    //Level up
    public int expNeeded;
    public int level;
    public int exp;

    public void InitializeCharacter() {
        vigor = stats.baseVigor;
        strength = stats.baseVigor;
        dexterity = stats.baseVigor;
        intelligence = stats.baseVigor;
        level = 1;
        exp = 0;
        expNeeded = 20;
        CalculateStats();
    }

    public void CalculateStats() {
        damage = usingDex ? dexterity : strength;
        defence = vigor;
        mdefence = intelligence;
        maxHp = vigor * 10;
        maxMana = intelligence * 10;
    }
}
