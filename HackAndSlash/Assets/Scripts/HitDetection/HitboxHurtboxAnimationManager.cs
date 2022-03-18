using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHurtboxAnimationManager : MonoBehaviour
{
    [SerializeField] private Collider hitbox = null;
    [SerializeField] private Collider hurtbox = null;

    public void MeleeAttackStart() {
        hitbox.gameObject.SetActive(true);
    }

    public void MeleeAttackEnd() {
        hitbox.gameObject.SetActive(false);
    }

    public void HitStart() {
        hurtbox.gameObject.SetActive(false);
    }

    public void HitEnd() {
        hurtbox.gameObject.SetActive(true);
    }
}
