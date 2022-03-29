using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBossManager : MonoBehaviour
{
    public BossProvaScript bossHealthBar;

    public bool bossFightIsActive;
    public bool bossHasBeenAwakened;
    public bool bossHasBeenDefeated;

    void Awake()
    {
        bossHealthBar = FindObjectOfType<BossProvaScript>();
    }

    public void ActiveBossFight()
    {
        bossFightIsActive = true;
        bossHasBeenAwakened = true;
        bossHealthBar.BoossLive();
    }

    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
    }

}
