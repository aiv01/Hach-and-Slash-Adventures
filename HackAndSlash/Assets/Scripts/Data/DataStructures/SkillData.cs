using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType {
    offensive,
    defensive,
    support
}
[CreateAssetMenu(fileName = "newSkill", menuName = "Data/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public SkillType type;
    public DamageType damageType;
    public Sprite skillSprite;
    public float damageMultiplier;
    public float knockbackMultiplier;
    public int manaCost;
    public string animationTrigger;
    [TextArea] public string description;
}
