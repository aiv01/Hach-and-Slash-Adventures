using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newClass", menuName = "Data/Class")]
public class ClassData : StatData
{
    public string className;
    public Sprite classToken;
    public WeaponType weaponRestriction;
    public int incrementVigor;
    public int incrementStrength;
    public int incrementDexterity;
    public int incrementIntelligence;
    public int[] unlockLevelSkill;
    public SkillLogic[] skills;
}
