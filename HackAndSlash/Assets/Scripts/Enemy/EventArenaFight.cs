using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArenaFight : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    public GameObject wallBattle;
    [SerializeField] private string key;
    private void Awake() {
        DataManagement.SetKey(key, false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!DataManagement.GetKey(key)) {
                DataManagement.enemyKilled = 0;
                Debug.Log("Player inside Trigger");
                OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
                wallBattle.SetActive(true);
                DataManagement.SetKey(key, true);
            }
        }
    }
}
