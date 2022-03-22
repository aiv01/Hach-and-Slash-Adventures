using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillLogic : MonoBehaviour{
    public SkillData skill;
    [SerializeField] protected CharacterStats character;
    public abstract void Skill();
    public abstract void OnSkillStart();
    public abstract void OnSkillEnd();
}
