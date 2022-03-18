using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRangeShoot : MonoBehaviour
{
    public EnemyAIShoot enemy;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemy.playerInDetectionRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            enemy.playerInDetectionRange = false;
        }
    }
}
