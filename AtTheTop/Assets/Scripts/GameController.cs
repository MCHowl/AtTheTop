using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public TMPro.TextMeshProUGUI energyText;
    public TMPro.TextMeshProUGUI moneyText;
    public GameObject pauseMenu;

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
        pauseMenu.SetActive(false);

        GameData.LoadPlayerData();
        EventList.InitialiseWorkEventList();
        EventList.InitialiseFriendEventList();
        EventList.InitialiseParentEventList();

        print("Current Day: " + GameData.CurrentDay);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Paused = true;
            pauseMenu.SetActive(true);
        }
    }

    private void LateUpdate() {
        moneyText.text = "Money:$" + GameData.CurrentMoney;
        //energyText.text = "Energy: " + GameData.CurrentEnergy + "/" + GameData.MaxEnergy;
        energyText.text = "Energy:" + GameData.CurrentEnergy / GameData.MaxEnergy * 100f + "%";
    }

    public void UnpauseGame() {
        Paused = false;
        pauseMenu.SetActive(false);
    }

    public void RestartDay() {
        GameData.CurrentEnergy = GameData.MaxEnergy;
        GameData.CurrentDay += 1;
        GameData.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
