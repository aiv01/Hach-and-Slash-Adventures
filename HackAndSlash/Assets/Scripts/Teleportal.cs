using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportal : MonoBehaviour
{
    public GameObject player;
    public Transform teleportelTo;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportelTo.transform.position;
    }
}
