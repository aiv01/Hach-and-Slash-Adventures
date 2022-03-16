using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float upDistance;
    public float backDistance;
    public float trackingSpeed;
    public float rotationSpeed;

    Vector3 targetPlayer;
    Quaternion quaternionTo;

    void LateUpdate()
    {
        targetPlayer = target.position - target.forward * backDistance + target.up * upDistance;

        transform.position = Vector3.Lerp(transform.position, targetPlayer, trackingSpeed * Time.deltaTime);

        quaternionTo = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, quaternionTo, rotationSpeed * Time.deltaTime);
    }
}
