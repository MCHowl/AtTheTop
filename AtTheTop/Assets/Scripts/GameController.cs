using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public TMPro.TextMeshProUGUI energyText;
    public TMPro.TextMeshProUGUI moneyText;

    bool isInGame = false;

    // Properties
    public bool InGame {
        get { return isInGame; }
        set { isInGame = value; }
    }

    public bool Paused { get; set; }

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
        GameData.LoadPlayerData();
    }

    private void LateUpdate() {
        moneyText.text = "Money: $" + GameData.CurrentMoney;
        energyText.text = "Energy: " + GameData.CurrentEnergy + "/" + GameData.MaxEnergy;
    }

    public void RestartDay() {
        GameData.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
