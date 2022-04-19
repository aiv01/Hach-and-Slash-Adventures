using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    private string creditsScene = "TitleScene";
    private ActivityManager activityManager;
    private ApplicationManager applicationManager;
    private Activity activity;
    private void Awake() {
        DontDestroyOnLoad(this);
        discord = new Discord.Discord(clientID, (ulong)CreateFlags.Default);
        applicationManager = discord.GetApplicationManager();
        activityManager = discord.GetActivityManager();
        activityManager.ClearActivity((result) => {
            if (result == Result.Ok) {
                Debug.Log("Working");
            }
            else {
                Debug.Log("No");
            }
        });
    }

    private void FixedUpdate() {
        if (SceneManager.GetActiveScene().name == menuScene) {
            MainMenuManager();
        }
        else if(SceneManager.GetActiveScene().name == gameScene){
            GameManager();
        }else if(SceneManager.GetActiveScene().name == creditsScene) {
            CreditsManager();
        }
        discord.RunCallbacks();
    }
    
    private void MainMenuManager() {
        activity = new Activity {
            State = "In main menu",
            Assets = {
                LargeImage = ellenAvatar
            }
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
        string image = GetClassImage(classData);
        string state = "As a level " + PlayerLogic.Instance.playerStats.level.ToString() + " " + classData.className;
        if (classData.className == "Empty") {
            state = "Finding out their archetype";
        }
        activity = new Activity {
            Details = "Wandering in the Hall",
            State = state,
            Assets = {
                LargeImage = ellenAvatar,
                SmallImage = image,
                SmallText = "Level " + PlayerLogic.Instance.playerStats.level.ToString() + " " + classData.className
            }
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

    private void CreditsManager() {
        ClassData classData = (ClassData)PlayerLogic.Instance.playerStats.stats;
        string image = GetClassImage(classData);
        string state = "As a level " + PlayerLogic.Instance.playerStats.level.ToString() + " " + classData.className;
        activity = new Activity {
            Details = "Has become a Champion",
            State = state,
            Assets = {
                LargeImage = ellenAvatar,
                SmallImage = image,
                SmallText = "Level " + PlayerLogic.Instance.playerStats.level.ToString() + " " + classData.className
            }
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Result.Ok) {
                Debug.Log("Working");
            }
            else {
                Debug.Log("No");
            }
        });
    }

    private string GetClassImage(ClassData classData) {
        if (classData.className == "Warrior") {
            return warriorToken;
        }
        else if (classData.className == "Ranger") {
            return rangerToken;
        }
        else if (classData.className == "Mage") {
            return mageToken;
        }
        return null;
    }

    private void OnApplicationQuit() {
        discord.Dispose();
    }
}
