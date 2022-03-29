using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBossManager : MonoBehaviour
{
    [SerializeField] private EventColliderBossFight bossFight;

    private void Start()
    {
        bossFight.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender,EventArgs e)
    {
        StartBattle();
        bossFight.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
    }
}
