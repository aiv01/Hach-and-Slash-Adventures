using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    //private int objectCollect = 0;
    public Rigidbody weapons;
    private bool isInsideTrigger = false;
    private bool isOpen = false;
    public Transform weaponsCreate;

    // Update is called once per frame
    void Update()
    {
        if(isInsideTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;

                if(isOpen == true)
                {
                    Debug.Log("Chest Open");
                    Rigidbody weaponsInstance;
                    weaponsInstance = Instantiate(weapons, weaponsCreate.position, weaponsCreate.rotation);
                    weaponsInstance.AddForce(Random.Range(-50, 50), 300f, -30f);

                }
                else if (isOpen == false)
                {
                    Debug.Log("Chest Closed");
                }

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Contact");
            isInsideTrigger = true;

            if (isOpen == true)
            {
                Debug.Log("Chest Open");

            }
            else if (isOpen == false)
            {
                Debug.Log("Chest Closed");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInsideTrigger = false;
        }
    }
}
