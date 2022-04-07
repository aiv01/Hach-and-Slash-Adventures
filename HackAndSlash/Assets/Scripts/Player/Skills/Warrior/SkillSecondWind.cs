using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSecondWind : SkillLogic {
    private Animator anim;
    [SerializeField] private ParticleSystem particles;
    public override void Skill(){
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public override void OnSkillStart() {
        base.OnSkillStart();
        ParticleSystem instance = Instantiate<ParticleSystem>(particles);
        instance.transform.parent = character.transform;
        instance.transform.localPosition = Vector3.zero;
        character.hp += character.vigor;
        if (character.hp > character.MaxHp) character.hp = character.MaxHp;
    }
    public override void OnSkillEnd() {
        //Do Nothing
    }
}

