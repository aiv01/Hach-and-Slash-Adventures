using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public enum Class {
    warrior,
    ranger,
    mage,
    last
}

[System.Serializable]
public struct ClassSetup {
    public ClassData classStats;
    public WeaponData startingWeapon;
}
public class ClassSelectionBehavior : MonoBehaviour
{
    private Class currentSelection;
    private bool hasChangedSelection;
    private Player input;
    private string skillChangeAxis = "HorizontalMovement";
    private string confirmButton = "Confirm";
    [SerializeField] private ClassSetup warriorSetup, rangerSetup, mageSetup;
    [SerializeField] private Image warriorImage, rangerImage, mageImage;
    private void Awake() {
        input = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput();
        ImageColor();
    }

    public void ChangeSelection(int selection) {
        currentSelection = (Class)selection;
    }

    public void ChooseClass(int selection) {
        switch ((Class) selection) {
            case Class.warrior:
                PlayerLogic.Instance.playerStats.stats = warriorSetup.classStats;
                PlayerLogic.Instance.playerStats.equippedWeapon = warriorSetup.startingWeapon;
                PlayerLogic.Instance.Initialize();
                gameObject.SetActive(false);
                break;
            case Class.ranger:
                PlayerLogic.Instance.playerStats.stats = rangerSetup.classStats;
                PlayerLogic.Instance.playerStats.equippedWeapon = rangerSetup.startingWeapon;
                PlayerLogic.Instance.Initialize();
                gameObject.SetActive(false);
                break;
            case Class.mage:
                PlayerLogic.Instance.playerStats.stats = mageSetup.classStats;
                PlayerLogic.Instance.playerStats.equippedWeapon = mageSetup.startingWeapon;
                PlayerLogic.Instance.Initialize();
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void ImageColor() {
        warriorImage.color = Color.white;
        rangerImage.color = Color.white;
        mageImage.color = Color.white;
        switch (currentSelection) {
            case Class.warrior:
                warriorImage.color = Color.yellow;
                break;
            case Class.ranger:
                rangerImage.color = Color.yellow;
                break;
            case Class.mage:
                mageImage.color = Color.yellow;
                break;
            default:
                break;
        }
    }
    private void ManageInput() {
        if (!hasChangedSelection) {
            currentSelection += (int)input.GetAxisRaw(skillChangeAxis);
            Debug.Log((int)input.GetAxisRaw(skillChangeAxis));
            hasChangedSelection = true;
            currentSelection = currentSelection >= Class.last ? Class.warrior : currentSelection < 0 ? Class.mage : currentSelection;
            Debug.Log(currentSelection);
        }
        if (input.GetAxisRaw(skillChangeAxis) == 0) {
            hasChangedSelection = false;
        }
        if (input.GetButtonDown(confirmButton)) {
            ChooseClass((int)currentSelection);
        }
    }
}
