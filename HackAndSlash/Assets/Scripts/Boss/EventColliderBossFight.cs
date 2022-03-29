using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBossFight : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        PlayerLogic player = other.GetComponent<PlayerLogic>();
        if(player != null)
        {
            OnPlayerEnterTrigger?.Invoke(this,EventArgs.Empty);
        }
    }
}
