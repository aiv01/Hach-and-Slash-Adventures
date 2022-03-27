using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicAttack : SkillLogic{
    private Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public virtual void OnAttackStart() {
        character.realDamage = Mathf.FloorToInt(character.damage * skill.damageMultiplier);
    }
    public virtual void OnAttackEnd() {
        character.realDamage = character.damage;
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}
