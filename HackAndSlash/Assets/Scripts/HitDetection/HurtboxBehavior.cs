using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtboxBehavior : MonoBehaviour
{
    [SerializeField] private string canGetHitBy;
    [SerializeField] private TextMeshPro textPrefab;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(canGetHitBy)) {
            Debug.Log("hit");
            CharacterStats otherStats = other.GetComponentInParent<CharacterStats>();
            CreateDamageText(otherStats.DealDamage(GetComponentInParent<CharacterStats>(), DamageType.physical).ToString());
        }
    }

    private void CreateDamageText(string text) {
        TextMeshPro instance = Instantiate<TextMeshPro>(textPrefab);
        instance.transform.SetParent(GameObject.Find("UI").transform);
        instance.transform.position = transform.position;
        instance.text = text;
    }
}
