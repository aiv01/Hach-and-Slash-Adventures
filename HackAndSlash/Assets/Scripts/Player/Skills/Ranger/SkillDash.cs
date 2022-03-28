using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDash : SkillLogic {
    [SerializeField] private float distance;
    [SerializeField] private LayerMask mask;
    private CapsuleCollider capsuleCollider;
    private Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        capsuleCollider = PlayerLogic.Instance.GetComponentInChildren<CapsuleCollider>();
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        RaycastHit hit;
        if(CanMove(character.transform.forward, out hit)) {
            Debug.Log("Hit");
            character.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }
        else {
            character.transform.position += new Vector3(character.transform.forward.x, 0, character.transform.forward.z) * distance;
        }
        anim.SetTrigger(skill.animationTrigger);
        character.mana -= skill.manaCost;
    }

    public override void OnSkillStart() {
        //Do nothing
    }
    public override void OnSkillEnd() {
        //Do nothing
    }

    private bool CanMove(Vector3 direction, out RaycastHit hit) {
        Debug.DrawLine(capsuleCollider.center + transform.position, transform.position + direction);
        RaycastHit capsuleHit;
        bool rayResult = !Physics.CapsuleCast(
            transform.TransformPoint(capsuleCollider.center + Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius)),
            transform.TransformPoint(capsuleCollider.center - Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius - 0.25f)),
            capsuleCollider.radius,
            direction,
            out capsuleHit,
            distance,
            mask);
        hit = capsuleHit;
        return rayResult;
    }
}

