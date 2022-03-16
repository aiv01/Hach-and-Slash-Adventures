using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    public StatData stats;
    public WeaponData equippedWeapon;
    [Header("Primary Stats")]
    public int vigor;
    public int strength;
    public int dexterity;
    public int intelligence;
    [Header("Secondary Stats")]
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
        strength = stats.baseStrength;
        dexterity = stats.baseDexterity;
        intelligence = stats.baseIntelligence;
        level = 1;
        exp = 0;
        expNeeded = 20;
        CalculateStats();
        hp = maxHp;
        mana = maxMana;
    }

    public void CalculateStats() {
        damage = equippedWeapon.baseDamage + (equippedWeapon.usingDex ? dexterity : strength);
        defence = vigor;
        mdefence = intelligence;
        maxHp = vigor * 10;
        maxMana = intelligence * 10;
    }

    private void Update() {
        damage = equippedWeapon.baseDamage + (equippedWeapon.usingDex ? dexterity : strength); //Temporary until real equip logic
    }
}
