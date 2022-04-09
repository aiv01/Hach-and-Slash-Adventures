using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordMenuManager : MonoBehaviour
{
    private Discord.Discord discord;
    private long clientID = 962397159087571004;
    private void Start() {
        discord = new Discord.Discord(clientID, (ulong)CreateFlags.Default);
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

    private void Update() {
        discord.RunCallbacks();
    }
}
