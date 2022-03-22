using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;

    public float myHealth;
    public float myMana;

    private float currentHealth;
    private float currentMana;
    private float calculateHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = myHealth;
        currentMana = myMana;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    void HandleBar()
    {
        calculateHealth = currentHealth / myHealth;
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, calculateHealth, Time.deltaTime);

        if(currentMana < myMana)
        {
            manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, 1f, Time.deltaTime * 0.01f);
            currentMana = Mathf.MoveTowards(currentMana / myMana, 1f, Time.deltaTime * 0.01f) * myMana;
        }

        if (currentHealth < myHealth)
        {
            healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 1f, Time.deltaTime * 0.01f);
            currentHealth = Mathf.MoveTowards(currentHealth / myHealth, 1f, Time.deltaTime * 0.01f) * myHealth;
        }

        if (currentMana < 0)
        {
            currentMana = 0;
        }

        if (currentHealth <= 0)
        {
            //Dead
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    public void ReduceMana(float mana)
    {
        if(mana <= currentMana)
        {
            currentMana -= mana;
            manaBar.fillAmount -= mana / myMana;
        }
        else
        {
            //Not enough Mana
        }
    }
}
