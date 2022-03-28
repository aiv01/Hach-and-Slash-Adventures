using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDash : SkillLogic {
    [SerializeField] private float distance;
    private Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        transform.position += new Vector3(character.transform.forward.x, 0, character.transform.forward.z) * distance;
        anim.SetTrigger(skill.animationTrigger);
        character.mana -= skill.manaCost;
    }
    public override void OnSkillStart() {
        //Do nothing
    }
    public override void OnSkillEnd() {
        //Do nothing
    }
}

