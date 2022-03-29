using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBossFight : MonoBehaviour
{
    EventBossManager bossManager;

    void Awake()
    {
        bossManager = FindObjectOfType<EventBossManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bossManager.ActiveBossFight();
        }
    }
}
