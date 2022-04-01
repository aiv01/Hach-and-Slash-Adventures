using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireball : MonoBehaviour
{
    [SerializeField] private CharacterStats fireballAoe;
    private CharacterStats projectileStats;

    private void Awake() {
        projectileStats = GetComponent<CharacterStats>();
    }

    private void OnDisable() {
        gameObject.SetActive(false);
        CharacterStats instance = Instantiate<CharacterStats>(fireballAoe);
        instance.transform.position = transform.position;
        instance.realDamage = projectileStats.realDamage;
    }
}
