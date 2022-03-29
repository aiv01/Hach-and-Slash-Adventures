using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterStats))]
public class Projectile : MonoBehaviour
{
    private CharacterStats stats;
    private Rigidbody rb;
    private TrailRenderer tr;
    [SerializeField] private bool piercing;
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private float timeToDespawn;
    [SerializeField] private float shakeStrength;
    [SerializeField] private string canGoThrough;
    private CameraShake ingameCamera;
    private float currentAliveTime;

    private void Awake() {
        stats = GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponentInChildren<TrailRenderer>();
        ingameCamera = GameObject.Find("IngameCamera").GetComponent<CameraShake>();
    }
    private void OnEnable() {
        currentAliveTime = timeToDespawn;
        stats.onDamageDealt.AddListener(ShakeCamera);
    }
    public void Shoot(CharacterStats shooter, Vector3 direction, float speed) {
        tr.Clear();
        stats.realDamage = shooter.realDamage;
        rb.velocity = direction * speed;
    }

    private void Update() {
        rb.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        currentAliveTime -= Time.deltaTime;
        if(currentAliveTime <= 0) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(canGoThrough)) {
            ParticleSystem instance = Instantiate<ParticleSystem>(hitParticle);
            instance.transform.position = transform.position;
            if (!piercing) gameObject.SetActive(false);
        }
    }

    private void ShakeCamera() {
        ingameCamera.Shake(shakeStrength);
    }
}
