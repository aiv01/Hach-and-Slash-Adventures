using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    //private int objectCollect = 0;
    bool instanceWeapons;
    public WeaponDrop weapons;
    private bool isInsideTrigger = false;
    private bool isOpen = false;
    public GameObject chest;
    public Transform weaponsCreate;
    public Animator anim;
    public static float defaultLifeTimer = 10;
    private float lifeTimer = 0;
    [SerializeField] private string chestFlag;

    // Update is called once per frame
    private void OnEnable() {
        DataManagement.SetKey(chestFlag, false);
    }
    void Update()
    {
        if (DataManagement.GetKey(chestFlag)) {
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
        }else if (!DataManagement.GetKey(chestFlag)) {
            isOpen = false;
            anim.SetBool("isOpen", isOpen);
        }
        lifeTimer += Time.deltaTime;
        if (isInsideTrigger == true)
        {
            if (PlayerLogic.Instance.isInteracting)
            {
                DataManagement.SetKey(chestFlag, true);
                isOpen = !isOpen;

                if(isOpen == true)
                {
                    Debug.Log("Chest Open");
                    anim.SetBool("isOpen", isOpen);
                    if(instanceWeapons == false)
                    {
                        WeaponDrop weaponsInstance;
                        Rigidbody weaponRb;
                        weaponsInstance = Instantiate(weapons, weaponsCreate.position, weaponsCreate.rotation);
                        weaponsInstance.Spawn();
                        weaponRb = weaponsInstance.GetComponent<Rigidbody>();
                        weaponRb.AddForce(Random.Range(-50, 50), 300f, -30f);
                        instanceWeapons = true;
                    }
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
}
