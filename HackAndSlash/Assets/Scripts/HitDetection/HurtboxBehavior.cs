using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxBehavior : MonoBehaviour
{
    [SerializeField] private string canGetHitBy;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(canGetHitBy)) {
            Debug.Log("hit");
            CharacterStats otherStats = other.GetComponentInParent<CharacterStats>();
            otherStats.DealDamage(GetComponentInParent<CharacterStats>(), DamageType.physical);
        }
    }
}
