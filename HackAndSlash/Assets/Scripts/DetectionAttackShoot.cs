using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionAttackShoot : MonoBehaviour
{

    public bool playerDetection = false;
    public float attackCooldown;
    private float currentAttackTime;

    public EnemyAIShoot enemy;

    // Start is called before the first frame update
    void Awake() {
        currentAttackTime = attackCooldown;
    }

    // Update is called once per frame
    void Update() {
        currentAttackTime -= Time.deltaTime;
        if (playerDetection == true && currentAttackTime <= 0) {
            FightInDetection();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerDetection = false;
        }
    }

    public void FightInDetection() {
        enemy.Attack();
        currentAttackTime = attackCooldown;
    }
}
