using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Ball : MonoBehaviour
{
    private float timerShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 6 * Time.deltaTime);
        transform.localScale += new Vector3(3, 3, 3) * Time.deltaTime;

        timerShoot += 1 * Time.deltaTime;

        if(timerShoot > 1f)
        {
            transform.localScale += new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            timerShoot = 0;
        }
    }
}
