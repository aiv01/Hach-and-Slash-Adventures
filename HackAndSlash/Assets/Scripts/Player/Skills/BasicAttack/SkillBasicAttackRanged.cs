using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicAttackRanged : SkillBasicAttack {
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform shootFrom;

    public override void OnAttackStart() {
        base.OnAttackStart();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("ShootPoint").transform;
        Projectile instance = bm.GetBullet();
        instance.transform.position = shootFrom.position;
        instance.gameObject.SetActive(true);
        instance.Shoot(character, character.transform.forward, shootSpeed, false);
    }
    public override void OnAttackEnd() {
        base.OnAttackEnd();
        //Do nothing
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}

