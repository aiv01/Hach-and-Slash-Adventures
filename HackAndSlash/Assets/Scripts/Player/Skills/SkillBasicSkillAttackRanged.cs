using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicSkillAttackRanged : SkillLogic {
    private Animator anim;
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private ProjectileType projectileType;

    public override void OnSkillStart() {
        base.OnSkillStart();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("Ellen_Left_Hand_Attach").transform;
        Projectile instance = bm.GetBullet(projectileType);
        instance.transform.position = shootFrom.position;
        instance.gameObject.SetActive(true);
        instance.Shoot(character, character.transform.forward, shootSpeed);
    }

    public override void OnSkillEnd() {
        //DoNothing
    }

    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        anim.SetTrigger(skill.animationTrigger);
        
    }
}

