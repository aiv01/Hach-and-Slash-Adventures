using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider capsuleCollider;

    public void MeleeAttackStart() {
        Debug.Log("Attack start");
    }

    public void MeleeAttackEnd() {
        Debug.Log("Attack end");
    }
}
