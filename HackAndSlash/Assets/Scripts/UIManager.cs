using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public TextMeshProUGUI vigor, strength, dexterity, intelligence;
    public TextMeshProUGUI defence, mdefence, damage, manaRegen;
    public TextMeshProUGUI weaponName, weaponDamage, weaponKnockback;

    void Update()
    {
        UpdatePlayerStatus();
    }

    public void UpdatePlayerStatus()
    {
        vigor.text = "" + characterStats.vigor;
        strength.text = "" + characterStats.strength;
        dexterity.text = "" + characterStats.dexterity;
        intelligence.text = "" + characterStats.intelligence;
        defence.text = "" + characterStats.defence;
        mdefence.text = "" + characterStats.mdefence;
        manaRegen.text = "" + characterStats.intelligence * 0.1f + "/s";
        damage.text = "" + characterStats.damage;
        weaponName.text = "" + characterStats.equippedWeapon.weaponName;
        weaponDamage.text = "" + characterStats.equippedWeapon.baseDamage + " + " + (characterStats.equippedWeapon.usingDex ? "Dexterity" : "Strength");
        weaponKnockback.text = "" + characterStats.equippedWeapon.knockback;
    }
}
