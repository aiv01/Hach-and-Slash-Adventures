using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private CharacterStats stats;
    private Rigidbody rb;
    private TrailRenderer tr;
    [SerializeField] private bool piercing;
    [SerializeField] private float timeToDespawn;
    private float currentAliveTime;

    private void Awake() {
        stats = GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponentInChildren<TrailRenderer>();
    }
    private void OnEnable() {
        currentAliveTime = timeToDespawn;
    }
    public void Shoot(CharacterStats shooter, Vector3 direction, float speed, bool piercing) {
        tr.Clear();
        this.piercing = piercing;
        stats.realDamage = shooter.realDamage;
        rb.velocity = direction * speed;
    }

    private void Update() {
        currentAliveTime -= Time.deltaTime;
        if(currentAliveTime <= 0) {
            gameObject.SetActive(false);
        }
    }
}
