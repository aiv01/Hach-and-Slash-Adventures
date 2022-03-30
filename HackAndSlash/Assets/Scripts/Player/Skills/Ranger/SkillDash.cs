using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDash : SkillLogic {
    [SerializeField] private float distance;
    [SerializeField] private float yOffset;
    [SerializeField] private LayerMask mask;
    [SerializeField] private TrailRenderer trail;
    private TrailRenderer instance;
    private CapsuleCollider capsuleCollider;
    private Animator anim;
    public override void Skill() {
        character = PlayerLogic.Instance.playerStats;
        capsuleCollider = PlayerLogic.Instance.GetComponentInChildren<CapsuleCollider>();
        anim = PlayerLogic.Instance.GetComponent<Animator>();
        instance = Instantiate<TrailRenderer>(trail);
        instance.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + yOffset, character.transform.position.z);
        RaycastHit hit;
        if(!CanMove(character.transform.forward, out hit)) {
            character.transform.position += new Vector3(character.transform.forward.x, 0, character.transform.forward.z) * (hit.distance - 1f);
        }
        else {
            character.transform.position += new Vector3(character.transform.forward.x, 0, character.transform.forward.z) * distance;
        }
        anim.SetTrigger(skill.animationTrigger);
        character.mana -= skill.manaCost;
    }

    public override void OnSkillStart() {
        if (instance == null) return;
        instance.transform.parent = character.transform;
        instance.transform.localPosition = new Vector3(0, yOffset, 0);
    }
    public override void OnSkillEnd() {
        //Do nothing
    }

    private bool CanMove(Vector3 direction, out RaycastHit hit) {
        Debug.DrawLine(capsuleCollider.center + transform.position, transform.position + direction);
        RaycastHit capsuleHit;
        bool rayResult = !Physics.CapsuleCast(
            character.transform.TransformPoint(capsuleCollider.center + Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius)),
            character.transform.TransformPoint(capsuleCollider.center - Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius - 0.25f)),
            capsuleCollider.radius,
            direction,
            out capsuleHit,
            distance,
            mask);
        hit = capsuleHit;
        return rayResult;
    }
}

