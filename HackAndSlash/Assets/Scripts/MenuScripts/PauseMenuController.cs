using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PauseMenuOption
{
    Resume,
    Menu,
    MenuController,
    Quit,
    last
}


public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool MenuControllerIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuControllerUI;
    private Player input;
    [SerializeField] private string openMenuKey;
    private PauseMenuOption currentSelection = PauseMenuOption.Resume;
    [SerializeField] private Transform[] selectorPositions;
    [SerializeField] private Image selector;
    private bool hasChangedSelection;
    private string skillChangeAxis = "VerticalMovement";
    private string confirmButton = "Confirm";


    void Awake()
    {
        input = ReInput.players.GetPlayer(0);
    }

    private void OnEnable() {
        Resume();
    }
    // Update is called once per frame
    void Update()
    {
        ManageInput();
        selector.rectTransform.parent = selectorPositions[(int)currentSelection];
        selector.rectTransform.localPosition = Vector3.zero;
        MenuUpdate();
    }

    void MenuUpdate()
    {
        if (input.GetButtonDown(openMenuKey))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            if (MenuControllerIsPaused)
            {
                MenuController();
            }
            else
            {
                MenuControllerExit();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuController()
    {
        pauseMenuControllerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuControllerExit()
    {
        pauseMenuControllerUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuMainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ManageInput()
    {
        if (!hasChangedSelection)
        {
            currentSelection -= (int)input.GetAxisRaw(skillChangeAxis);
            hasChangedSelection = true;
            currentSelection = currentSelection >= PauseMenuOption.last ? PauseMenuOption.Resume : currentSelection < 0 ? PauseMenuOption.Quit : currentSelection;
        }
        if (input.GetAxisRaw(skillChangeAxis) == 0)
        {
            hasChangedSelection = false;
        }
        if (input.GetButtonDown(confirmButton)) {
            switch (currentSelection) {
                case PauseMenuOption.Resume:
                    Resume();
                    break;
                case PauseMenuOption.Menu:
                    LoadMenu();
                    break;
                case PauseMenuOption.MenuController:
                    MenuController();
                    break;
                case PauseMenuOption.Quit:
                    QuitGame();
                    break;
                case PauseMenuOption.last:
                    break;
                default:
                    break;
            }
        }
    }
    public void ChangeSelection(PauseMenuOption option)
    {
        currentSelection = option;
    }

}
