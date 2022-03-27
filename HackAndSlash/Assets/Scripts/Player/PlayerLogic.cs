using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(CharacterStats))]
public class PlayerLogic : MonoBehaviour
{
    [Header("Level")]
    public int maxLevel;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [Header("Input")]
    //Rewired
    private Player input;

    //Rotation
    [SerializeField] private bool usingMouse;

    //Input strings
    [SerializeField] private string horizontalMovementAxis;
    [SerializeField] private string verticalMovementAxis;
    [SerializeField] private string horizontalLookAxis;
    [SerializeField] private string verticalLookAxis;
    [SerializeField] private string skillChangeAxis;
    [SerializeField] private string attackButton;
    [SerializeField] private string skillButton;
    [SerializeField] private string skill1key;
    [SerializeField] private string skill2key;
    [SerializeField] private string skill3key;
    [SerializeField] private string skill4key;
    [SerializeField] private string openMenuKey;

    [Header("References")]
    [SerializeField] public CharacterStats playerStats;
    [SerializeField] private Movement movement;
    [SerializeField] private Transform meleeWeapon;
    [SerializeField] private Transform rangedWeapon;

    [Header("Animation managing")]
    [SerializeField] private Animator anim;
    [SerializeField] private RuntimeAnimatorController meleeAnimation;
    [SerializeField] private RuntimeAnimatorController rangedAnimation;

    //Hit detection
    [Header("Hit detection")]
    public bool hit;

    //Skill
    [SerializeField] private int currentSkillId = 0;
    private SkillLogic currentSkill;
    private bool isUsingSkill;
    private bool hasChangedSkill;

    //Debug stuff
    [SerializeField] private WeaponData[] weapons;
    //Singleton
    private static PlayerLogic instance;
    public static PlayerLogic Instance { get { return instance; } }

    public PlayerPanel playerPanel;

    private void Awake() {
        instance = this;
        input = ReInput.players.GetPlayer(0);
        playerStats = GetComponent<CharacterStats>();
        UnlockSkill();
    }
    public void LevelUp() {
        //Get class and increment level
        ClassData currentClass = (ClassData)playerStats.stats;
        playerStats.level++;
        playerStats.exp = 0;
        playerStats.expNeeded *= 2;

        //Increment stats
        playerStats.vigor += currentClass.incrementVigor;
        playerStats.strength += currentClass.incrementStrength;
        playerStats.dexterity += currentClass.incrementDexterity;
        playerStats.intelligence += currentClass.incrementIntelligence;

        //Calculate new stats
        int oldMaxHp = playerStats.MaxHp;
        int oldMaxMana = playerStats.MaxMana;
        playerStats.CalculateStats();
        playerStats.hp += playerStats.MaxHp - oldMaxHp;
        playerStats.mana += playerStats.MaxMana - oldMaxMana;

        UnlockSkill();
    }

    private void Update() {
        ManageInput();

        currentSkill = playerStats.skills[currentSkillId] != null ? playerStats.skills[currentSkillId] : null;

        if(playerStats.equippedWeapon.type == WeaponType.ranged) {
            anim.runtimeAnimatorController = rangedAnimation;
            rangedWeapon.gameObject.SetActive(true);
            meleeWeapon.gameObject.SetActive(false);
        }
        else {
            anim.runtimeAnimatorController = meleeAnimation;
            rangedWeapon.gameObject.SetActive(false);
            meleeWeapon.gameObject.SetActive(true);
        }
    }

    private void ManageInput() {
        //Character Rotation
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            usingMouse = true;
        }
        else {
            usingMouse = false;
        }
        if (usingMouse) {
            movement.LookAtMouse();
        }
        else {
            Vector3 lookInput = new Vector3(input.GetAxis(horizontalLookAxis),
                        0,
                        input.GetAxis(verticalLookAxis));
            if (lookInput != Vector3.zero) {
                movement.Rotate(lookInput);
            }
        }

        //Character movement
        Vector3 moveInput = new Vector3(input.GetAxis(horizontalMovementAxis) * speed,
            0,
            input.GetAxis(verticalMovementAxis) * speed);
        movement.Move(moveInput);

        //Character attack
        if (input.GetButtonDown(attackButton)) {
            playerStats.equippedWeapon.baseAttack.Skill();
        }
        if (input.GetButtonDown(skillButton)) {
            UseSkillWithNum(currentSkillId);
        }

        //Select skill
        if (!isUsingSkill && !hasChangedSkill) {
            currentSkillId += (int)input.GetAxis(skillChangeAxis);
            hasChangedSkill = true;
            currentSkillId = currentSkillId >= 4 ? 0 : currentSkillId;
            currentSkillId = currentSkillId < 0 ? 3 : currentSkillId;
        }
        if (input.GetAxis(skillChangeAxis) == 0) {
            hasChangedSkill = false;
        }

        //Skill with num
        if (input.GetButtonDown(skill1key)) {
            UseSkillWithNum(0);
        }
        if (input.GetButtonDown(skill2key)) {
            UseSkillWithNum(1);
        }
        if (input.GetButtonDown(skill3key)) {
            UseSkillWithNum(2);
        }
        if (input.GetButtonDown(skill4key)) {
            UseSkillWithNum(3);
        }


        if (input.GetButtonDown(openMenuKey)) {
            playerPanel.OpenClose();
        }
    }

    public void GetExp(int exp) {
        playerStats.exp += exp;
        if(playerStats.exp >= playerStats.expNeeded) {
            LevelUp();
        }
    }

    //Attack and Skill Management
    public void SkillStart() {
        currentSkill.OnSkillStart();
    }
    public void SkillEnd() {
        currentSkill.OnSkillEnd();
        isUsingSkill = false;
    }
    public void AttackStart() {
        playerStats.equippedWeapon.baseAttack.OnAttackStart();
    }
    public void AttackEnd() {
        playerStats.equippedWeapon.baseAttack.OnAttackEnd();
    }
    private void UnlockSkill() {
        ClassData currentClass = (ClassData)playerStats.stats;
        for (int i = 0; i < currentClass.skills.Length; i++) {
            if (playerStats.level >= currentClass.unlockLevelSkill[i]) {
                playerStats.skills[i] = currentClass.skills[i];
            }
        }
    }

    private void UseSkillWithNum(int num) {
        if (!isUsingSkill) {
            currentSkillId = num;
            if(currentSkill != null) {
                if(playerStats.mana >= currentSkill.skill.manaCost) {
                    isUsingSkill = true;
                    playerStats.skills[currentSkillId].Skill();
                }
                else {
                    Debug.Log("Not enough mana");
                }
            }
            
        }
    }

    //Debug stuff
    private void OnGUI()
    {
        //GUI.Label(new Rect(0, 40, 1920, 1080),
        //    "Level: " + playerStats.level + "\n" +
        //    "HP: " + playerStats.hp + "/" + playerStats.MaxHp + "\n" +
        //    "Mana: " + playerStats.mana + "/" + playerStats.MaxMana + "\n" +
        //    "Exp: " + playerStats.exp + "/" + playerStats.expNeeded + "\n\n" +
        //    "Vigor: " + playerStats.vigor + "\n" +
        //    "Strength: " + playerStats.strength + "\n" +
        //    "Dexterity: " + playerStats.dexterity + "\n" +
        //    "Intelligence: " + playerStats.intelligence + "\n\n" +
        //    "Damage: " + playerStats.damage + "\n" +
        //    "Defence: " + playerStats.defence + "\n" +
        //    "Magic Defence: " + playerStats.mdefence + "\n" +
        //    "Current Weapon: " + playerStats.equippedWeapon.weaponName + "\n" +
        //    "Current Skill: " + (currentSkill != null ? currentSkill.skill.skillName : "None") + "\n"
        //    );
        if (GUI.Button(new Rect(600, 0, 100, 20), "Initialize")) {
            playerStats.InitializeCharacter();
        }
        if (GUI.Button(new Rect(600, 20, 100, 20), "Level up")) {
            if (playerStats.level < maxLevel) {
                LevelUp();
            }
        }
        for (int i = 0; i < weapons.Length; i++) {
            if (GUI.Button(new Rect(700, 0 + (i * 20), 150, 20), weapons[i].weaponName)) {
                playerStats.equippedWeapon = weapons[i];
            }
        }
        if (GUI.Button(new Rect(850, 0, 100, 20), "Save")) {
            DataManagement.Save();
        }
        if (GUI.Button(new Rect(850, 20, 100, 20), "Load")) {
            DataManagement.Load();
        }
    }
}
