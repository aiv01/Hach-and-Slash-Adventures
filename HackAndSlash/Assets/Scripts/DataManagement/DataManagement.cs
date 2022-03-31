using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
[System.Serializable]
public struct WorldData {
    public List<string> keys;
    public List<bool> values;
}
public static class DataManagement
{
    private static PlayerData playerData;
    private static WorldData worldData;
    private static CharacterStats playerStats;
    private static Dictionary<string, bool> flags = new Dictionary<string, bool>();

    private static string playerPath = @"Data.json";
    private static string worldPath = @"WorldData.json";

    //World logic
    public static int enemyKilled;

    public static void Save() {
        //Player
        playerData = GetData();
        Debug.Log(JsonUtility.ToJson(playerData));
        File.WriteAllText(playerPath, JsonUtility.ToJson(playerData));

        //Flags
        worldData = GetFlagData();
        string worldJsonData = JsonUtility.ToJson(worldData);
        Debug.Log(worldJsonData);
        File.WriteAllText(worldPath, worldJsonData);
    }

    public static void Load() {
        string jsonData = File.ReadAllText(playerPath);
        Debug.Log(jsonData);
        //Load stats
        JsonUtility.FromJsonOverwrite(jsonData, PlayerLogic.Instance.playerStats);
        PlayerLogic.Instance.playerStats.CalculateStats();

        //Load position
        JsonUtility.FromJsonOverwrite(jsonData, playerData);
        PlayerLogic.Instance.transform.position = playerData.position;
        PlayerLogic.Instance.transform.rotation = playerData.rotation;

        //Load world flags
        LoadFlagData();
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

    private static WorldData GetFlagData() {
        WorldData data = new WorldData();
        data.keys = flags.Keys.ToList();
        data.values = flags.Values.ToList();
        return data;
    }

    private static void LoadFlagData() {
        worldData = new WorldData();
        worldData.keys = new List<string>();
        worldData.values = new List<bool>();
        string jsonWorldData = File.ReadAllText(worldPath);
        JsonUtility.FromJsonOverwrite(jsonWorldData, worldData);
        for (int i = 0; i < worldData.keys.Count; i++) {
            flags[worldData.keys[i]] = worldData.values[i];
        }
    }


    public static void SetKey(string key, bool value) {
        if (!flags.ContainsKey(key)) {
            flags.Add(key, value);
        }
        else {
            flags[key] = value;
        }
    }

    public static bool GetKey(string key) {
        return flags[key];
    }
}
