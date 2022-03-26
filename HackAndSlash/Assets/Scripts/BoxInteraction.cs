using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    //private int objectCollect = 0;
    bool instanceWeapons;
    public Rigidbody weapons;
    private bool isInsideTrigger = false;
    private bool isOpen = false;
    public GameObject chest;
    public Transform weaponsCreate;
    public Animator anim;
    public static float defaultLifeTimer = 10;
    private float lifeTimer = 0;

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (isInsideTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;

                if(isOpen == true)
                {
                    Debug.Log("Chest Open");
                    anim.SetBool("isOpen", isOpen);
                    if(instanceWeapons == false)
                    {
                        Rigidbody weaponsInstance;
                        weaponsInstance = Instantiate(weapons, weaponsCreate.position, weaponsCreate.rotation);
                        weaponsInstance.AddForce(Random.Range(-50, 50), 300f, 30f);
                        instanceWeapons = true;
                    }

                    StartCoroutine(WaitAndDestroy());
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInsideTrigger = false;
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(chest);
    }
}
