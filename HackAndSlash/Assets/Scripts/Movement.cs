using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private string speedParameter;

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask rayLayer;
    Ray mouseRay;

    public void Move(Vector3 velocity) {
        animator.SetFloat(speedParameter, velocity.z);
    }

    public void Rotate(Vector3 rotation) {

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
}
