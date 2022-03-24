using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public struct PlayerData {
    public StatData stats;
    public WeaponData equippedWeapon;
    public int level;
    public int exp;
    public int expNeeded;

    public int vigor;
    public int strength;
    public int dexterity;
    public int intelligence;

    public int hp;
    public int mana;

    public SkillLogic[] skills;

    public Vector3 position;
    public Quaternion rotation;
}
public static class DataManagement
{
    private static PlayerData data;
    private static CharacterStats playerStats;
    //Needs worldlogic here

    private static string path = $"Data.json";

    public static void Save() {
        data = GetData();
        Debug.Log(JsonUtility.ToJson(data, true));
        File.WriteAllText(path, JsonUtility.ToJson(data, true));
    }

    public static void Load() {
        string jsonData = File.ReadAllText(path);
        Debug.Log(jsonData);
        //Load stats
        JsonUtility.FromJsonOverwrite(jsonData, PlayerLogic.Instance.playerStats);
        PlayerLogic.Instance.playerStats.CalculateStats();

        //Load position
        JsonUtility.FromJsonOverwrite(jsonData, data);
        PlayerLogic.Instance.transform.position = data.position;
        PlayerLogic.Instance.transform.rotation = data.rotation;
    }

    private static PlayerData GetData() {
        playerStats = PlayerLogic.Instance.playerStats;
        PlayerData data = new PlayerData();

        data.stats = playerStats.stats;
        data.equippedWeapon = playerStats.equippedWeapon;
        data.level = playerStats.level;
        data.expNeeded = playerStats.expNeeded;
        data.exp = playerStats.exp;

        data.vigor = playerStats.vigor;
        data.strength = playerStats.strength;
        data.dexterity = playerStats.dexterity;
        data.intelligence = playerStats.intelligence;

        data.hp = playerStats.hp;
        data.mana = playerStats.mana;

        data.skills = playerStats.skills;

        data.position = playerStats.transform.position;
        data.rotation = playerStats.transform.rotation;

        return data;
    }
}
