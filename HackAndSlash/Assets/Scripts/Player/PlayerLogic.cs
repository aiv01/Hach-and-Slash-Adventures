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

    [Header("References")]
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private Movement movement;

    //Singleton
    private static PlayerLogic instance;
    public static PlayerLogic Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        input = ReInput.players.GetPlayer(0);
        playerStats = GetComponent<CharacterStats>();
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
    }

    private void Update() {
        ManageInput();
    }

    private void ManageInput() {
        //Character Rotation
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
            movement.Attack();
        }
    }

    public void GetExp(int exp) {
        playerStats.exp += exp;
        if(playerStats.exp >= playerStats.expNeeded) {
            LevelUp();
        }
    }

    //Debug stuff
    private void OnGUI() {
        GUI.Label(new Rect(0, 40, 1920, 1080),
            "Level: " + playerStats.level + "\n" +
            "HP: " + playerStats.hp + "/" + playerStats.MaxHp + "\n" +
            "Mana: " + playerStats.mana + "/" + playerStats.MaxMana + "\n" +
            "Exp: " + playerStats.exp + "/" + playerStats.expNeeded + "\n\n" +
            "Vigor: " + playerStats.vigor + "\n" +
            "Strength: " + playerStats.strength + "\n" +
            "Dexterity: " + playerStats.dexterity + "\n" +
            "Intelligence: " + playerStats.intelligence + "\n\n" +
            "Damage: " + playerStats.damage + "\n" +
            "Defence: " + playerStats.defence + "\n" +
            "Magic Defence: " + playerStats.mdefence + "\n" +
            "Current Weapon: " + playerStats.equippedWeapon.weaponName + "\n"
            );
        if (GUI.Button(new Rect(0, 0, 100, 20), "Initialize")) {
            playerStats.InitializeCharacter();
        }
        if (GUI.Button(new Rect(0, 20, 100, 20), "Level up")) {
            if (playerStats.level < maxLevel) {
                LevelUp();
            }
        }
    }
}
