using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHeavyBlow : SkillLogic {
    private Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public override void OnSkillStart() {
        character.realDamage = Mathf.FloorToInt(character.damage * skill.damageMultiplier);
    }
    public override void OnSkillEnd() {
        character.realDamage = character.damage;
    }
}

