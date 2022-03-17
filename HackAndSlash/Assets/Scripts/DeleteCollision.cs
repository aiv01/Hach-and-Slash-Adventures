using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollision : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
        Object.Destroy(this.gameObject);
    }
}
