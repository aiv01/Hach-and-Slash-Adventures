using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    melee,
    ranged,
    magic
}

[CreateAssetMenu(fileName = "newWeapon", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponType type;
    public bool usingDex;
    public int baseDamage;
}
