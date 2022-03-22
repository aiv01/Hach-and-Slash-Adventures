using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public Text vigorText, dexterityText, mdefenceText, intelligenceText;
    public Text strengthText, defenceText, cWeaponText,damageText;

    void Start()
    {
        UpdatePlayerStatus();
    }

    public void UpdatePlayerStatus()
    {
        vigorText.text = "" + characterStats.vigor;
        dexterityText.text = "" + characterStats.dexterity;
        mdefenceText.text = "" + characterStats.mdefence;
        intelligenceText.text = "" + characterStats.intelligence;
        strengthText.text = "" + characterStats.strength;
        defenceText.text = "" + characterStats.defence;
        cWeaponText.text = "" + characterStats.equippedWeapon.weaponName;
        damageText.text = "" + characterStats.dexterity;
    }
}
