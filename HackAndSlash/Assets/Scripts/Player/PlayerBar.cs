using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBar : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;
    public Image expBar;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;

    private CharacterStats playerData;
    private float calculatedHealth;
    private float calculatedMana;
    private float calculatedExp;

    private void Awake() {
        
    }
    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    void HandleBar()
    {
        playerData = PlayerLogic.Instance.playerStats;
        calculatedHealth = (float)playerData.hp / playerData.MaxHp;
        calculatedMana = (float)playerData.mana / playerData.MaxMana;
        calculatedExp = (float)playerData.exp / playerData.expNeeded;

        healthText.text = playerData.hp + "/" + playerData.MaxHp;
        manaText.text = playerData.mana + "/" + playerData.MaxMana;
        expText.text = playerData.exp + "/" + playerData.expNeeded;
        levelText.text = playerData.level.ToString();
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, calculatedHealth, Time.deltaTime);
        manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, calculatedMana, Time.deltaTime);
        expBar.fillAmount = Mathf.MoveTowards(expBar.fillAmount, calculatedExp, Time.deltaTime);
    }
}
