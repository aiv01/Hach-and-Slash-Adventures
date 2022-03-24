using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManagement
{
    private static CharacterStats playerStats;
    //Needs worldlogic here

    private struct PlayerData {
        public StatData playerClass;
        public WeaponData equippedWeapon;
        public int level;
        public int exp;
        public int expNeeded;
        public int vigor;
        public int strength;
        public int dexterity;
        public int intelligence;

        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

    }
    public static void Save() {
        PlayerData data = GetData();
        Debug.Log(JsonUtility.ToJson(data, true));
    }

    private static PlayerData GetData() {
        playerStats = PlayerLogic.Instance.playerStats;
        PlayerData data = new PlayerData();
        data.playerClass = playerStats.stats;
        data.equippedWeapon = playerStats.equippedWeapon;
        data.expNeeded = playerStats.expNeeded;
        data.exp = playerStats.exp;
        data.vigor = playerStats.vigor;
        data.strength = playerStats.strength;
        data.dexterity = playerStats.dexterity;
        data.intelligence = playerStats.intelligence;
        return data;
    }
}
