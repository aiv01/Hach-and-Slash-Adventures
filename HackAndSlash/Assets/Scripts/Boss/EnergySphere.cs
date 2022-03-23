using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour
{
    private float timerShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerShoot += 1 * Time.deltaTime;

        if(timerShoot > 3)
        {
            gameObject.SetActive(false);
            timerShoot = 0;
        }

        transform.Translate(Vector3.forward * 12.5f * Time.deltaTime);
    }
}
