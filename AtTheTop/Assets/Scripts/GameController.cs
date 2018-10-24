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
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Paused = true;
            pauseMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F12)) {
            GameData.CurrentMoney += 100;
        }

        if (Input.GetKeyDown(KeyCode.F11)) {
            GameData.CurrentEnergy = GameData.MaxEnergy;
        }

        if (Input.GetKeyDown(KeyCode.F10)) {
            GameData.CurrentDay += 1;
        }
    }

    private void LateUpdate() {
        moneyText.text = "$" + GameData.CurrentMoney.ToString("F2");
        //energyText.text = "Energy: " + GameData.CurrentEnergy + "/" + GameData.MaxEnergy;
        energyText.text = (GameData.CurrentEnergy / GameData.MaxEnergy * 100f).ToString("F1") + "%";
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
