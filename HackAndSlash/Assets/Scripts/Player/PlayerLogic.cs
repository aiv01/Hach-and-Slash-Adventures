using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class PlayerLogic : MonoBehaviour
{
    [Header("Level")]
    public int maxLevel;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 currentDirection;

    [Header("Input")]
    //Rewired
    private Player input;

    //Rotation
    private bool usingMouse;

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

    private void Awake() {
        input = ReInput.players.GetPlayer(0);
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

    private void OnGUI() {
        if (GUI.Button(new Rect(0, 0, 100, 20), "Inizialize")) {
            playerStats.InitializeCharacter();
        }
        if (GUI.Button(new Rect(0, 20, 100, 20), "Level up")) {
            if(playerStats.level < maxLevel) {
                LevelUp();
            }
        }
        if (GUI.Button(new Rect(0, 40, 100, 20), "Attack")) {
            Debug.Log("Dealt " + playerStats.damage + " damage with " + playerStats.equippedWeapon.weaponName);
        }
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
}
