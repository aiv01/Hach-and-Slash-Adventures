using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private CharacterStats stats;
    private Rigidbody rb;

    public void Shoot(CharacterStats shooter, Vector3 direction, float speed) {
        stats.realDamage = shooter.realDamage;
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }
}
