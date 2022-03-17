using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionAttack : MonoBehaviour
{

    public bool playerDetection = false;
    public DateTime nextDamage;
    public float fightAfterTime;

    public EnemyAI enemy;

    // Start is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerDetection == true)
        {
            FightInDetection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetection = false;
        }
    }

    public void FightInDetection()
    {
        if(nextDamage <= DateTime.Now)
        {
            enemy.Attack();
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(fightAfterTime));
        }
    }
}
