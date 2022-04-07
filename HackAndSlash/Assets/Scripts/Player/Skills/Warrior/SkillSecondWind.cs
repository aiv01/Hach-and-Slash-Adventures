using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSecondWind : SkillLogic {
    private Animator anim;
    public override void Skill(){
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public override void OnSkillStart() {
        base.OnSkillStart();
        character.hp += character.vigor;
        if (character.hp > character.MaxHp) character.hp = character.MaxHp;
    }
    public override void OnSkillEnd() {
        //Do Nothing
    }
}

