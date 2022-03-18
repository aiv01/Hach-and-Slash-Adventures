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
    public float timeBetweenAttacks;
    public GameObject projectile;


    // Start is called before the first frame update
    void Awake()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInDetectionRange == true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(attackStateName))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
            if (!isAttacking)
            {
                enemyNavMesh.transform.LookAt(playerTarget);
                enemyNavMesh.SetDestination(playerTarget.position + new Vector3(0, 0, 0.099f));
            }
            Run();
        }
        else
        {
            Idle();
        }
    }

    public void Run()
    {
        enemyNavMesh.speed = 0.4f;
        anim.SetTrigger("Run");
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");

        if (!isAttacking)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            isAttacking = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        isAttacking = false;
    }


    public void Idle()
    {
        anim.SetTrigger("Idle");
    }
}
