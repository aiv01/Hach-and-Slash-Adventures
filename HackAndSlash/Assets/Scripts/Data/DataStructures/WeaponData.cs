using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    melee,
    ranged,
    magic,
    creatura
}

[CreateAssetMenu(fileName = "newWeapon", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponType type;
    public SkillBasicAttack baseAttack;
    public DamageType damageType;
    public bool usingDex;
    public bool canStagger;
    public int baseDamage;
    public float knockback;
}
