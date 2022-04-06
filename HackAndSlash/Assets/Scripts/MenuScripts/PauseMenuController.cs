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
    Quit,
    last
}


public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private Player input;
    [SerializeField] private string openMenuKey;
    private int currentSelection = (int)PauseMenuOption.Resume;
    [SerializeField] private float spacing;
    private Vector3 originalSelectorPosition;
    [SerializeField] private Image selector;
    private bool hasChangedSelection;
    private string skillChangeAxis = "VerticalMovement";


    void Awake()
    {
        input = ReInput.players.GetPlayer(0);
        originalSelectorPosition = selector.rectTransform.position;
    }

    private void OnEnable() {
        Resume();
    }
    // Update is called once per frame
    void Update()
    {
        ManageInput();
        selector.rectTransform.position = new Vector3(
            originalSelectorPosition.x,
            originalSelectorPosition.y - spacing * currentSelection,
            originalSelectorPosition.z);
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
            currentSelection = currentSelection >= (int)PauseMenuOption.last ? (int)PauseMenuOption.Resume : currentSelection < 0 ? (int)PauseMenuOption.Quit : currentSelection;
        }
        if (input.GetAxisRaw(skillChangeAxis) == 0)
        {
            hasChangedSelection = false;
        }
    }

}
