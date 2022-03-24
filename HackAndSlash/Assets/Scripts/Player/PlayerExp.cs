using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public int maxExp;
    public float updateExp;

    public Image expBar;

    public float expIncreasedForSecond;
    public int playerLevel;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel = 1;
        expIncreasedForSecond = 5f;
        maxExp = 25;
        updateExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateExp += expIncreasedForSecond * Time.deltaTime;
        expBar.fillAmount = updateExp / maxExp;

        levelText.text = playerLevel + "";

        if(updateExp >= maxExp)
        {
            playerLevel++;
            updateExp = 0;
            maxExp += maxExp;
        }
    }
}
