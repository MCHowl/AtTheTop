using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
    // Properties
    public static float CurrentEnergy { get; set; }
    public static float MaxEnergy { get; set; }

    public static float CurrentMoney { get; set; }

    public static int CurrentDay { get; set; }

    public static int FriendRelationshipLevel { get; set; }
    public static int ParentRelationshipLevel { get; set; }

    public static int Upgrade1Level { get; set; }
    public static int Upgrade2Level { get; set; }
    public static int Upgrade3Level { get; set; }
    public static int Upgrade4Level { get; set; }
    public static int Upgrade5Level { get; set; }

    // Functions
    public static void LoadPlayerData() {
        MaxEnergy = PlayerPrefs.GetFloat("maxEnergy", 250);
        CurrentEnergy = PlayerPrefs.GetFloat("currentEnergy", MaxEnergy);

        CurrentMoney = PlayerPrefs.GetFloat("currentMoney");

        CurrentDay = PlayerPrefs.GetInt("currentDay", 1);

        FriendRelationshipLevel = PlayerPrefs.GetInt("friendlevel", 10);
        ParentRelationshipLevel = PlayerPrefs.GetInt("parentlevel", 10);

        Upgrade1Level = PlayerPrefs.GetInt("upgrade1Level");
        Upgrade2Level = PlayerPrefs.GetInt("upgrade2Level");
        Upgrade3Level = PlayerPrefs.GetInt("upgrade3Level");
        Upgrade4Level = PlayerPrefs.GetInt("upgrade4Level");
        Upgrade5Level = PlayerPrefs.GetInt("upgrade5Level");
    }

    public static void SavePlayerData() {
        PlayerPrefs.SetFloat("maxEnergy", MaxEnergy);
        PlayerPrefs.SetFloat("currentEnergy", CurrentEnergy);

        PlayerPrefs.SetFloat("currentMoney", CurrentMoney);

        PlayerPrefs.SetInt("currentDay", CurrentDay);

        PlayerPrefs.SetInt("friendLevel", FriendRelationshipLevel);
        PlayerPrefs.SetInt("parnetLevel", ParentRelationshipLevel);

        PlayerPrefs.SetInt("upgrade1Level", Upgrade1Level);
        PlayerPrefs.SetInt("upgrade2Level", Upgrade2Level);
        PlayerPrefs.SetInt("upgrade3Level", Upgrade3Level);
        PlayerPrefs.SetInt("upgrade4Level", Upgrade4Level);
        PlayerPrefs.SetInt("upgrade5Level", Upgrade5Level);
    }
}
