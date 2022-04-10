using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBarrage : SkillBasicSkillAttack {
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private int projectiles;
    [SerializeField] private float waitTime;
    public override void Skill() {
        base.Skill();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("ShootPoint").transform;
    }

    public override void OnSkillStart() {
        base.OnSkillStart();
        Shoot();
    }
    public override void OnSkillEnd() {
        base.OnSkillEnd();
    }

    private void Shoot() {
        Projectile instance = bm.GetBullet(projectileType);
        instance.transform.position = shootFrom.position;
        instance.gameObject.SetActive(true);
        instance.Shoot(character, character.transform.forward, shootSpeed);
    }
}

