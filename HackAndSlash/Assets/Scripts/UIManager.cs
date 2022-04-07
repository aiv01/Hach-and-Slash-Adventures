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
    public TextMeshProUGUI skillName, skillType, skillCost, skillDesc;
    public Image selector;
    public Image skill;
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
        UpdateSkillDescription();
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
            if(PlayerLogic.Instance.playerStats.skills[i] != null) {
                skills[i].sprite = PlayerLogic.Instance.playerStats.skills[i].skill.skillSprite;
            }
            if (currentClass.unlockLevelSkill[i] > characterStats.level) {
                skills[i].color = Color.gray;
            }
            else {
                skills[i].color = Color.white;
            }
        }
    }

    private void UpdateSkillDescription() {
        if (PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId] == null) {
            skill.gameObject.SetActive(false); 
            return;
        }
        skill.gameObject.SetActive(true);
        skillName.text = PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.skillName;
        skillType.text = PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.damageType == DamageType.physical ? "<color=#FF0000>Physical</color>" : "<color=#0000FF>Magical</color>";
        skillCost.text = PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.manaCost.ToString();
        skillDesc.text = PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.description;

        //Calculate damage
        int damage;
        if(PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.damageType == DamageType.magical) {
            damage = Mathf.FloorToInt(
                (PlayerLogic.Instance.playerStats.damage + PlayerLogic.Instance.playerStats.intelligence) * 
                PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.damageMultiplier);

        }
        else {
            damage = Mathf.FloorToInt(PlayerLogic.Instance.playerStats.damage * 
                PlayerLogic.Instance.playerStats.skills[PlayerLogic.Instance.CurrentSkillId].skill.damageMultiplier);
        }
        skillDesc.text = skillDesc.text.Replace("<damage>", damage.ToString());
        skillDesc.text = skillDesc.text.Replace("<vigor>", PlayerLogic.Instance.playerStats.vigor.ToString());
    }

    private void CheckSelectorPosition() {
        selector.rectTransform.localPosition = new Vector3(selectorOriginalPosition.x + (spacing * PlayerLogic.Instance.CurrentSkillId), selectorOriginalPosition.y, selectorOriginalPosition.z);
    }
}
