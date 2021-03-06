using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    private Transform trackingToObject;
    private Rigidbody rb;
    [SerializeField] private float trackingSpeed;
    [SerializeField] private ParticleSystem despawnParticle;
    [SerializeField] private AudioClip[] despawnAudio;

    private void Awake() {
        trackingToObject = GameObject.Find("Player").transform.GetChild(0).transform;
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        rb.velocity = Vector3.Lerp(rb.velocity,
            (new Vector3(trackingToObject.position.x, transform.position.y, trackingToObject.position.z) - transform.position).normalized * rb.velocity.magnitude,
            trackingSpeed * Time.deltaTime);
    }

    private void OnDisable() {
        ParticleSystem instance = Instantiate<ParticleSystem>(despawnParticle);
        instance.GetComponent<AudioSource>().clip = despawnAudio[Random.Range(0, despawnAudio.Length - 1)];
        instance.GetComponent<AudioSource>().Play();
        instance.transform.position = transform.position;
    }
}
