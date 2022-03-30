using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBattleFight : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
    }

    [SerializeField] private EventArenaFight colliderTrigger;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, EventArgs e)
    {
        if(state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        state = State.Active;
    }
}
