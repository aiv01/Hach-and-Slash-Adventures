using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public int level = 0;
    public int exp;
    //Hit detection
    public bool isHit;
    //Damage calculation
    public int realDamage;
    //Mana regeneration
    private float addManaTime = 1;
    private float currentManaTime;
    //Skills
    public SkillLogic[] skills;
    [Header("Event")]
    public UnityEvent onDamageDealt;
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
        onDamageDealt.Invoke();
        return totalDamage;
    }
                                                                                                                            
    private void Update() {
        if(hp < 0) {
            hp = 0;
        }
        if(mana < 0) {
            mana = 0;
        }
        if(equippedWeapon != null) {
            damage = equippedWeapon.baseDamage + (equippedWeapon.usingDex ? dexterity : strength); //Temporary until real equip logic
        }
        //Mana regeneration
        if(mana < maxMana) {
            currentManaTime -= Time.deltaTime * intelligence * 0.1f;
            if(currentManaTime <= 0) {
                mana++;
                currentManaTime = addManaTime;
            }
        }
    }
}
