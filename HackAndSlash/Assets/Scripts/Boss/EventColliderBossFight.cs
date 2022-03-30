using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBossFight : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerEnterTrigger?.Invoke(this,EventArgs.Empty);
        }
    }
}
