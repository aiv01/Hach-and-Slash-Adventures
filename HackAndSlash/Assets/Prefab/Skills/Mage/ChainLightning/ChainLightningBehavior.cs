using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightningBehavior : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float angle;
    private CharacterStats stats;
    private BulletManager bm;
    private Rigidbody rb;
    private void Awake() {
        stats = GetComponent<CharacterStats>();
        bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + (Quaternion.AngleAxis(angle, Vector3.up) * (transform.forward * distance)));
        Gizmos.DrawLine(transform.position, transform.position + (Quaternion.AngleAxis(-angle, Vector3.up) * (transform.forward * distance)));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            rb.velocity = Vector3.zero;
            SpawnLightnings(other);
        }
    }
    public void SpawnLightnings(Collider other) {
        EnemyLogic[] enemies = FindObjectsOfType<EnemyLogic>();
        foreach (EnemyLogic enemy in enemies) {
            if (other.GetComponentInParent<EnemyLogic>() == enemy) continue;
            float enemyDistance = (transform.position - enemy.transform.position).magnitude;
            float enemyAngle = Vector3.Angle(enemy.transform.position - transform.position, transform.forward);
            Debug.Log(enemyDistance + " " + enemyAngle);
            if (enemyDistance <= distance) {
                if(enemyAngle <= angle) {
                    Projectile instance = bm.GetBullet(ProjectileType.lightning);
                    instance.transform.position = transform.position;
                    instance.Shoot(stats, (
                        new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z) - 
                        new Vector3(transform.position.x, 0, transform.position.z)).normalized, 60);
                    instance.gameObject.SetActive(true);
                }
            }
        }
    }
}
