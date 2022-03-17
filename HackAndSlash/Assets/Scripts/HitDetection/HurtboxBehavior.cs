using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtboxBehavior : MonoBehaviour
{
    [SerializeField] private string canGetHitBy;
    [SerializeField] private TextMeshPro debugDamage; //Only for debugging
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(canGetHitBy)) {
            Debug.Log("hit");
            CharacterStats otherStats = other.GetComponentInParent<CharacterStats>();
            debugDamage.text = otherStats.DealDamage(GetComponentInParent<CharacterStats>(), DamageType.physical).ToString();
        }
    }
}
