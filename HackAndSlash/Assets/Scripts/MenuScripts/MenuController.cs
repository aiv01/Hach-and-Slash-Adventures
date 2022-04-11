using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;
using System.IO;

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
    private MenuOption currentSelection = MenuOption.newgame;
    [SerializeField] private Transform[] selectorPositions;
    [SerializeField] private Image selector;
    [SerializeField] private Image loading;
    private bool hasChangedSelection;
    private string skillChangeAxis = "VerticalMovement";

    private void Awake() {
        input = ReInput.players.GetPlayer(0);
    }
    private void Update() {
        ManageInput();
        selector.rectTransform.parent = selectorPositions[(int)currentSelection];
        selector.rectTransform.localPosition = Vector3.zero;
    }
    public void NewGameDialogYes()
    {
        DataManagement.newGame = true;
        loading.gameObject.SetActive(true);
        StartCoroutine(LoadScene(newGameLevel));
    }

    public void LoadGameDialogYes()
    {
        if (File.Exists(@"Data/PlayerData.json"))
        {
            DataManagement.needsLoading = true;
            loading.gameObject.SetActive(true);
            StartCoroutine(LoadScene(newGameLevel));
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
        if (!hasChangedSelection) {
            currentSelection -= (int)input.GetAxisRaw(skillChangeAxis);
            Debug.Log((int)input.GetAxisRaw(skillChangeAxis));
            hasChangedSelection = true;
            currentSelection = currentSelection >= MenuOption.last ? MenuOption.newgame : currentSelection < 0 ? MenuOption.exit : currentSelection;
            Debug.Log(currentSelection);
        }
        if (input.GetAxisRaw(skillChangeAxis) == 0) {
            hasChangedSelection = false;
        }
        if (input.GetButton("Confirm")) {
            switch (currentSelection) {
                case MenuOption.newgame:
                    NewGameDialogYes();
                    break;
                case MenuOption.loadgame:
                    LoadGameDialogYes();
                    break;
                case MenuOption.exit:
                    ExitButton();
                    break;
                case MenuOption.last:
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator LoadScene(string scene) {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(scene);
        sceneLoad.allowSceneActivation = false;
        while(sceneLoad.progress < 0.9f) {
            yield return null;
        }
        sceneLoad.allowSceneActivation = true;
        yield return null;
    }
}
