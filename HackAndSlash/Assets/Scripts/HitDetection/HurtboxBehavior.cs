using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtboxBehavior : MonoBehaviour
{
    [SerializeField] private string canGetHitBy;
    [SerializeField] private TextMeshPro textPrefab;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] hitAudio;

    private void Awake() {
        audioSource = GetComponentInParent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(canGetHitBy)) {
            Debug.Log("hit");
            CharacterStats otherStats = other.GetComponentInParent<CharacterStats>();
            CreateDamageText(otherStats.DealDamage(GetComponentInParent<CharacterStats>(), otherStats.equippedWeapon.damageType).ToString());
            audioSource.PlayOneShot(hitAudio[Random.Range(0, hitAudio.Length)]);
        }
    }

    private void CreateDamageText(string text) {
        if (textPrefab == null) return;
        TextMeshPro instance = Instantiate<TextMeshPro>(textPrefab);
        instance.transform.SetParent(GameObject.Find("UI").transform);
        instance.transform.position = transform.position;
        instance.text = text;
    }
}
