using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Debug.Log("Out of screen");
    }
}
