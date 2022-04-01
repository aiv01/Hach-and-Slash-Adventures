using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public enum MenuOption {
    newgame,
    loadgame,
    exit,
    last
}
public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    private Player input;
    public string newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
    private int currentSelection = (int)MenuOption.newgame;
    [SerializeField] private float spacing;
    private Vector3 originalSelectorPosition;
    [SerializeField] private Image selector;
    private bool hasChangedSelection;
    private string skillChangeAxis = "VerticalMovement";

    private void Awake() {
        input = ReInput.players.GetPlayer(0);
        originalSelectorPosition = selector.rectTransform.position;
    }
    private void Update() {
        ManageInput();
        selector.rectTransform.position = new Vector3(
            originalSelectorPosition.x, 
            originalSelectorPosition.y - spacing * currentSelection, 
            originalSelectorPosition.z);
    }
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void ManageInput() {
        if (!hasChangedSelection)
        {
            currentSelection -= (int)input.GetAxisRaw(skillChangeAxis);
            Debug.Log((int)input.GetAxisRaw(skillChangeAxis));
            hasChangedSelection = true;
            currentSelection = currentSelection >= (int)MenuOption.last ? (int)MenuOption.newgame : currentSelection < 0 ? (int)MenuOption.exit : currentSelection;
            Debug.Log(currentSelection);
        }
        if (input.GetAxisRaw(skillChangeAxis) == 0)
        {
            hasChangedSelection = false;
        }
    }
}
