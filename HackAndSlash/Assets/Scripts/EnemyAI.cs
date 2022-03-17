using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool playerInDetectionRange = false;
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
            enemyNavMesh.transform.LookAt(playerTarget);
            enemyNavMesh.SetDestination(playerTarget.position + new Vector3(0, 0, 0.099f));
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
}
