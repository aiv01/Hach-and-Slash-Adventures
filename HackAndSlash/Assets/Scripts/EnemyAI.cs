using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool playerInDetectionRange = false;
    private bool isAttacking;
    [SerializeField] private string attackStateName;
    public Transform playerTarget;
    NavMeshAgent enemyNavMesh;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerInDetectionRange == true)
        {
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
        else {
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
    }

    public void Idle() {
        anim.SetTrigger("Idle");
    }
}