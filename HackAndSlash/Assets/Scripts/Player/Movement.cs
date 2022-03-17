using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private string speedParameter;

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private LayerMask moveLayers;
    [SerializeField] private CapsuleCollider capsuleCollider;
    private Ray mouseRay;

    public void Move(Vector3 velocity) {
        if (CanMove(velocity.normalized)) {
            animator.SetFloat(speedParameter, velocity.magnitude);
        }
        else {
            animator.SetFloat(speedParameter, 0);
        }
        if(velocity.magnitude != 0) {
            transform.rotation = Quaternion.LookRotation(velocity.normalized, Vector3.up);
        }
    }

    public void Rotate(Vector3 direction) {
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public void LookAtMouse() {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseRay = Camera.main.ScreenPointToRay(mouseScreenPos);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, rayLayer)) {
            Vector3 hitPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 lookDirection = (hitPosition - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(mouseRay);
    }

    private bool CanMove(Vector3 direction) {
        Debug.DrawLine(capsuleCollider.center + transform.position, transform.position + direction);
        return !Physics.CapsuleCast(
            transform.TransformPoint(capsuleCollider.center + Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius)),
            transform.TransformPoint(capsuleCollider.center - Vector3.up * (capsuleCollider.height * 0.5f - capsuleCollider.radius - 0.25f)),
            capsuleCollider.radius,
            direction,
            0.5f,
            moveLayers);
    }

    public void Attack() {
        animator.SetTrigger("Attack");
    }
}
