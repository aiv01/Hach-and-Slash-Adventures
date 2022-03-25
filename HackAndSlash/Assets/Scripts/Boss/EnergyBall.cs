using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if(timer > 3)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
    }
}
