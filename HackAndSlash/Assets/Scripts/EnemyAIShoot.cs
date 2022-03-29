using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIShoot : MonoBehaviour
{
    public bool playerInDetectionRange = false;
    private bool isAttacking;
    [SerializeField] private string attackStateName;
    public Transform playerTarget;
    NavMeshAgent enemyNavMesh;
    Animator anim;
    EnemyLogic logic;
    private BulletManager br;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        playerTarget = GameObject.Find("Player").transform.GetChild(0).transform;
        br = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        enemyNavMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        logic = GetComponent<EnemyLogic>();
    }

    // Update is called once per frame
    void Update() {
        if (playerInDetectionRange == true && !logic.enemyStats.isHit) {
            anim.ResetTrigger("Hit");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(attackStateName)) {
                isAttacking = true;
            }
            else {
                isAttacking = false;
            }
            if (!isAttacking) {
                enemyNavMesh.transform.LookAt(playerTarget);
                enemyNavMesh.SetDestination(playerTarget.position + new Vector3(0, 0, 0.099f));
            }
            Run();
        }
        else if (logic.enemyStats.isHit && !isAttacking) {
            Hit();
        }
        else {
            anim.ResetTrigger("Hit");
            Idle();
        }
    }

    public void Run() {
        logic.enemyStats.isHit = false;
        enemyNavMesh.speed = 0.4f;
        anim.SetTrigger("Run");
    }

    public void Attack() {
        logic.enemyStats.isHit = false;
        enemyNavMesh.speed = 0f;
        anim.SetTrigger("Attack");
    }

    public void Idle() {
        logic.enemyStats.isHit = false;
        enemyNavMesh.speed = 0f;
        anim.SetTrigger("Idle");
    }

    public void Hit() {
        logic.enemyStats.isHit = false;
        enemyNavMesh.speed = 0f;
        anim.SetTrigger("Hit");
    }

    public void Shoot() {
        Projectile instance = br.GetBullet(ProjectileType.enemy);
        instance.transform.position = shootPoint.position;
        instance.Shoot(logic.enemyStats, transform.forward, shootSpeed);
        instance.gameObject.SetActive(true);
    }
}
