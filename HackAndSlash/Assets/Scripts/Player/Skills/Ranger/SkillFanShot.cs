using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFanShot : SkillBasicSkillAttack {
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootArc;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private int bulletToShoot;

    public override void Skill() {
        base.Skill();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("ShootPoint").transform;
        for (int i = Mathf.FloorToInt(bulletToShoot * -0.5f); i < Mathf.FloorToInt(bulletToShoot * 0.5f); i++) {
            Projectile instance = bm.GetBullet(projectileType);
            instance.gameObject.SetActive(true);
            instance.transform.position = shootFrom.position;
            instance.Shoot(character, character.transform.forward, shootSpeed);
            instance.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis((shootArc / bulletToShoot) * i, Vector3.up) * instance.GetComponent<Rigidbody>().velocity;

        }
    }
    public override void OnSkillStart() {
        base.OnSkillStart();
        //Do nothing
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}

