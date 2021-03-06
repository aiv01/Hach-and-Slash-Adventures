using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicSkillAttack : SkillLogic {
    protected Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public override void OnSkillStart() {
        base.OnSkillStart();
        character.realDamage = Mathf.FloorToInt(character.damage * skill.damageMultiplier);
    }
    public override void OnSkillEnd() {
        character.realDamage = character.damage;
    }
}

