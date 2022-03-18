using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float timeToLive;
    [SerializeField] private float speed;
    private float actualTime;

    private void OnEnable() {
        actualTime = timeToLive;
    }
    void Update()
    {
        actualTime -= Time.deltaTime;
        if(actualTime > 0) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else {
            Destroy(gameObject);
        }
    }
}
