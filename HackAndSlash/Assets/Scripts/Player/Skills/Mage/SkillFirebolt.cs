using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFirebolt : SkillBasicSkillAttackRanged {

    public override void OnSkillStart() {
        character.realDamage = Mathf.FloorToInt((character.damage + character.intelligence) * skill.damageMultiplier);
        base.OnSkillStart();
        
        
    }

    public override void OnSkillEnd() {
        character.realDamage = character.damage;
    }

    public override void Skill() {
        base.Skill();
        
    }
}

