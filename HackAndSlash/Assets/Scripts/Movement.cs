using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private string speedParameter;

    [SerializeField] private Animator animator;

    public void Move(Vector3 velocity) {
        animator.SetFloat(speedParameter, velocity.z);
    }

    public void Rotate(Vector3 rotation) {

    }
}
