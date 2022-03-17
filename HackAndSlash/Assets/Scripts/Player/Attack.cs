using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider hitbox;
    public bool hasHit;

    public void MeleeAttackStart() {
        hitbox.gameObject.SetActive(true);
    }

    public void MeleeAttackEnd() {
        hitbox.gameObject.SetActive(false);
    }
}
