using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicAttackRanged : SkillBasicAttack {
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private ProjectileType projectileType;

    public override void OnAttackStart() {
        base.OnAttackStart();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("ShootPoint").transform;
        Projectile instance = bm.GetBullet(projectileType);
        instance.transform.position = shootFrom.position;
        instance.gameObject.SetActive(true);
        instance.Shoot(character, character.transform.forward, shootSpeed);
    }
    public override void OnAttackEnd() {
        base.OnAttackEnd();
        //Do nothing
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}

