using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArenaFight : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player inside Trigger");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
