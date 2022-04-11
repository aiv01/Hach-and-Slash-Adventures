using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    private float currentFade;
    [SerializeField] private Transform gameOverText;
    private Image gameOverBlack;

    private void Awake() {
        gameOverBlack = GetComponent<Image>();
    }

    private void OnEnable() {
        currentFade = 0;
    }
    // Update is called once per frame
    void Update()
    {
        currentFade += Time.deltaTime * fadeSpeed;
        gameOverBlack.color = new Color(
            gameOverBlack.color.r,
            gameOverBlack.color.g,
            gameOverBlack.color.b,
            Mathf.Lerp(0, 1, currentFade)
            );
        if(currentFade >= 1) {
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        DataManagement.Load();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
