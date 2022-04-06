using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHurtboxAnimationManager : MonoBehaviour
{
    [SerializeField] private Collider hitbox = null;
    [SerializeField] private Collider hurtbox = null;

    public void AttackStart() {
        if (hitbox == null) return;
        hitbox.gameObject.SetActive(true);
    }

    public void AttackEnd() {
        if (hitbox == null) return;
        hitbox.gameObject.SetActive(false);
    }

    public void HitStart() {
        if (hurtbox == null) return;
        hurtbox.gameObject.SetActive(false);
    }

    public void HitEnd() {
        if (hurtbox == null) return;
        hurtbox.gameObject.SetActive(true);
    }
}
