using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBasicAttackRangedCreatura : SkillBasicAttack {
    private BulletManager bm;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootArc;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private ProjectileType projectileType;

    public override void OnAttackStart() {
        base.OnAttackStart();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        shootFrom = GameObject.Find("ShootPoint").transform;
        Projectile instance = bm.GetBullet(projectileType);
        instance.gameObject.SetActive(true);
        Projectile instance1 = bm.GetBullet(projectileType);
        instance1.gameObject.SetActive(true);
        Projectile instance2 = bm.GetBullet(projectileType);
        instance2.gameObject.SetActive(true);
        instance.transform.position = shootFrom.position;
        instance1.transform.position = shootFrom.position;
        instance2.transform.position = shootFrom.position;
        instance.Shoot(character, character.transform.forward, shootSpeed);
        instance1.Shoot(character, character.transform.forward, shootSpeed);
        instance2.Shoot(character, character.transform.forward, shootSpeed);
        instance1.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(shootArc, Vector3.up) * instance1.GetComponent<Rigidbody>().velocity;
        instance2.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(-shootArc, Vector3.up) * instance2.GetComponent<Rigidbody>().velocity;
    }
    public override void OnAttackEnd() {
        base.OnAttackEnd();
        //Do nothing
    }

    public override void OnSkillEnd() {
        //DoNothing
    }
}

