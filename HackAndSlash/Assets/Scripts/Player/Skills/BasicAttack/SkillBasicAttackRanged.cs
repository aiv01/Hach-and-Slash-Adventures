using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicAttackRanged : SkillBasicAttack {
    public override void OnAttackStart() {
        base.OnAttackStart();
        //Shoot projectile
    }
    public override void OnAttackEnd() {
        base.OnAttackEnd();
        //Do nothing
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}

