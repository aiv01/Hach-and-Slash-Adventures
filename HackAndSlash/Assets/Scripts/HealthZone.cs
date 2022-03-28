using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && PlayerLogic.Instance.playerStats.hp < 1)
        {
            StartCoroutine("Heal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StopCoroutine("Heal");
        }
    }

    IEnumerator Heal()
    {
        for(float currentHealth = PlayerLogic.Instance.playerStats.hp; currentHealth <= 1; currentHealth += 0.05f)
        {
            PlayerLogic.Instance.playerStats.hp = (int)currentHealth;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        PlayerLogic.Instance.playerStats.hp = 1;
    }
}
