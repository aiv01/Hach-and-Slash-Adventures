using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    physical,
    magical
}

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
    //Hit detection
    [HideInInspector] public bool isHit;
    //Damage calculation
    public int realDamage;
    //Skills
    public SkillLogic[] skills;
    private void Awake() {
        skills = new SkillLogic[4];
    }
    public void InitializeCharacter() {
        vigor = stats.baseVigor;
        strength = stats.baseStrength;
        dexterity = stats.baseDexterity;
        intelligence = stats.baseIntelligence;
        level = 1;
        exp = 0;
        expNeeded = 20;
        CalculateStats();
        realDamage = damage;
        hp = maxHp;
        mana = maxMana;
    }

    public void CalculateStats() {
        damage = equippedWeapon.baseDamage + (equippedWeapon.usingDex ? dexterity : strength);
        realDamage = damage;
        defence = vigor;
        mdefence = intelligence;
        maxHp = vigor * 10;
        maxMana = intelligence * 10;
    }

    public int DealDamage(CharacterStats target, DamageType type) {
        int totalDamage = Mathf.Max(1, realDamage - (type == DamageType.physical ? target.defence : target.mdefence));
        target.hp -= totalDamage;
        target.transform.position += (new Vector3(transform.forward.x, 0, transform.forward.z)) * equippedWeapon.knockback;
        if (equippedWeapon.canStagger) {
            target.isHit = true;
        }
        return totalDamage;
    }
                                                                                                                            
    private void Update() {
        damage = equippedWeapon.baseDamage + (equippedWeapon.usingDex ? dexterity : strength); //Temporary until real equip logic
    }
}
