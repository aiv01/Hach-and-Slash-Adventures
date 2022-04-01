using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float timeToLive;
    private float currentLive;
    // Start is called before the first frame update
    private void OnEnable() {
        currentLive = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        currentLive -= Time.deltaTime;
        if(currentLive <= 0) {
            Destroy(gameObject);
        }
    }
}
