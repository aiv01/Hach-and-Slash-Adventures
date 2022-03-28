using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHurtboxAnimationManager : MonoBehaviour
{
    [SerializeField] private Collider hitbox = null;
    [SerializeField] private Collider hurtbox = null;

    public void AttackStart() {
        hitbox.gameObject.SetActive(true);
    }

    public void AttackEnd() {
        hitbox.gameObject.SetActive(false);
    }

    public void HitStart() {
        hurtbox.gameObject.SetActive(false);
    }

    public void HitEnd() {
        hurtbox.gameObject.SetActive(true);
    }
}
