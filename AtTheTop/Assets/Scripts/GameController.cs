using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public TMPro.TextMeshProUGUI energyText;
    public TMPro.TextMeshProUGUI moneyText;

    // Properties
    public static bool Paused { get; set; }
    public static bool InOffice { get; set; }

    // Listeners
    private void OnEnable() {
        ScreenFade.DayEndEvent += RestartDay;
    }

    private void OnDisable() {
        ScreenFade.DayEndEvent -= RestartDay;
    }

    // Game Management
    private void Start() {
        Paused = true;
        InOffice = false;
        GameData.LoadPlayerData();

        print("Current Day: " + GameData.CurrentDay);
    }

    private void LateUpdate() {
        moneyText.text = "Money: $" + GameData.CurrentMoney;
        energyText.text = "Energy: " + GameData.CurrentEnergy + "/" + GameData.MaxEnergy;
    }

    public void RestartDay() {
        GameData.CurrentEnergy = GameData.MaxEnergy;
        GameData.CurrentDay += 1;
        GameData.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
