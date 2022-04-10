using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Discord;

public class DiscordManager : MonoBehaviour
{
    private Discord.Discord discord;
    private long clientID = 962397159087571004;
    private string ellenAvatar = "ellenportrait";
    private string warriorToken = "warriortoken";
    private string rangerToken = "rangertoken";
    private string mageToken = "magetoken";
    private string menuScene = "MenuMainScene";
    private string gameScene = "PrototypeAmbientScene";
    private void Start() {
        discord = new Discord.Discord(clientID, (ulong)CreateFlags.Default);
    }

    private void Update() {
        if(SceneManager.GetActiveScene().name == menuScene) {
            MainMenuManager();
        }
        else if(SceneManager.GetActiveScene().name == gameScene){
            GameManager();
        }
        discord.RunCallbacks();
    }
    
    private void MainMenuManager() {
        ActivityManager activityManager = discord.GetActivityManager();
        Activity activity = new Activity {
            State = "In main menu",
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Result.Ok) {
                Debug.Log("Working");
            }
            else {
                Debug.Log("No");
            }
        }
        );
    }

    private void GameManager() {
        ClassData classData = (ClassData)PlayerLogic.Instance.playerStats.stats;
        ActivityManager activityManager = discord.GetActivityManager();
        Activity activity = new Activity {
            Details = "Wandering in the Hall",
            State = "As a level " + PlayerLogic.Instance.playerStats.level.ToString() + " " + classData.className
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Result.Ok) {
                Debug.Log("Working");
            }
            else {
                Debug.Log("No");
            }
        }
        );
    }
}
