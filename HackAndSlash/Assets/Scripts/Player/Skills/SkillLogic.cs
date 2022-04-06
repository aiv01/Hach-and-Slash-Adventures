using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillLogic : MonoBehaviour{
    public SkillData skill;
    [SerializeField] protected CharacterStats character;
    public AudioClip[] audio;
    public abstract void Skill();
    public virtual void OnSkillStart() {
        character.mana -= skill.manaCost;
    }
    public abstract void OnSkillEnd();
}
