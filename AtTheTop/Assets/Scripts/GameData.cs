using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
    // Properties
    public static int CurrentEnergy { get; set; }
    public static int MaxEnergy { get; set; }

    public static int CurrentMoney { get; set; }

    public static int CurrentDay { get; set; }

    public static int Upgrade1Level { get; set; }
    public static int Upgrade2Level { get; set; }
    public static int Upgrade3Level { get; set; }
    public static int Upgrade4Level { get; set; }
    public static int Upgrade5Level { get; set; }

    // Functions
    public static void LoadPlayerData() {
        MaxEnergy = PlayerPrefs.GetInt("maxEnergy", 250);
        CurrentEnergy = PlayerPrefs.GetInt("currentEnergy", MaxEnergy);

        CurrentMoney = PlayerPrefs.GetInt("currentMoney");

        CurrentDay = PlayerPrefs.GetInt("currentDay", 1);

        Upgrade1Level = PlayerPrefs.GetInt("upgrade1Level");
        Upgrade2Level = PlayerPrefs.GetInt("upgrade2Level");
        Upgrade3Level = PlayerPrefs.GetInt("upgrade3Level");
        Upgrade4Level = PlayerPrefs.GetInt("upgrade4Level");
        Upgrade5Level = PlayerPrefs.GetInt("upgrade5Level");
    }

    public static void SavePlayerData() {
        PlayerPrefs.SetInt("maxEnergy", MaxEnergy);
        PlayerPrefs.SetInt("currentEnergy", CurrentEnergy);

        PlayerPrefs.SetInt("currentMoney", CurrentMoney);

        PlayerPrefs.SetInt("currentDay", CurrentDay);

        PlayerPrefs.SetInt("upgrade1Level", Upgrade1Level);
        PlayerPrefs.SetInt("upgrade2Level", Upgrade2Level);
        PlayerPrefs.SetInt("upgrade3Level", Upgrade3Level);
        PlayerPrefs.SetInt("upgrade4Level", Upgrade4Level);
        PlayerPrefs.SetInt("upgrade5Level", Upgrade5Level);
    }
}
