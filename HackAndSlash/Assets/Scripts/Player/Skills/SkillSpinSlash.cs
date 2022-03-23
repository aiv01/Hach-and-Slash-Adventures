using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpinSlash : SkillLogic {
    private Animator anim;
    [SerializeField] private Collider hitbox;
    private Collider instance;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
    }
    public override void OnSkillStart() {
        character.realDamage = Mathf.FloorToInt(character.damage * skill.damageMultiplier);
        instance = Instantiate<Collider>(hitbox);
        instance.transform.SetParent(PlayerLogic.Instance.transform.GetChild(0).transform);
        instance.transform.localPosition = Vector3.zero;
    }
    public override void OnSkillEnd() {
        character.realDamage = character.damage;
        Destroy(instance.gameObject);
    }
}

