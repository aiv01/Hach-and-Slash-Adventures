using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : MonoBehaviour
{
    float charge;
    public float hpPerSecond = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            charge = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            charge += hpPerSecond * Time.deltaTime;
            if(charge >= 1)
            {
                PlayerLogic.Instance.playerStats.hp = Mathf.Clamp(PlayerLogic.Instance.playerStats.hp + 1, 0, PlayerLogic.Instance.playerStats.MaxHp);
                charge -= 1;
            }
            
        }
    }
}
