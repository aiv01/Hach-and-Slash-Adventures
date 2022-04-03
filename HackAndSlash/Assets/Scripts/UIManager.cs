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
    public Image selector;
    public Image[] skills;
    [SerializeField] private float spacing;
    private Vector3 selectorOriginalPosition;
    [SerializeField] private Image classSelection;

    private void Awake() {
        selectorOriginalPosition = selector.rectTransform.localPosition;
    }
    void Update()
    {
        UpdatePlayerStatus();
        CheckAvaiableSkill();
        CheckSelectorPosition();
        if (DataManagement.newGame) {
            classSelection.gameObject.SetActive(true);
            DataManagement.newGame = false;
        }
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

    private void CheckAvaiableSkill() {
        ClassData currentClass = (ClassData)characterStats.stats;
        for (int i = 0; i < currentClass.skills.Length; i++) {
            if (currentClass.unlockLevelSkill[i] > characterStats.level) {
                skills[i].color = Color.gray;
            }
            else {
                skills[i].color = Color.white;
            }
        }
    }

    private void CheckSelectorPosition() {
        selector.rectTransform.localPosition = new Vector3(selectorOriginalPosition.x + (spacing * PlayerLogic.Instance.CurrentSkillId), selectorOriginalPosition.y, selectorOriginalPosition.z);
    }
}
