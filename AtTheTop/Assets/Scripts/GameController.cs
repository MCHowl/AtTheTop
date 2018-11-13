using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public TMPro.TextMeshProUGUI energyText;
    public TMPro.TextMeshProUGUI moneyText;
    public GameObject pauseMenu;
    public Image fadeScreen;

	public Texture2D silver_cursor;
	public Texture2D gold_cursor;

	public GameObject floatingText;
	private float prevMoney;
	private float prevEnergy;

    // Properties
    public static bool Paused { get; set; }
    public static bool InOffice { get; set; }

    // Game Management
    private void Start() {
        Paused = true;
        InOffice = false;
        pauseMenu.SetActive(false);

        GameData.LoadPlayerData();
        EventList.InitialiseEventLists();
		EventResponseList.InitialiseResponseLists();
		GetComponent<RoomSpawner>().InitialiseRooms();

		prevMoney = GameData.CurrentMoney;
		prevEnergy = GameData.CurrentEnergy;

		if (GameData.Upgrade1Level == 2) {
			Cursor.SetCursor(silver_cursor, Vector2.zero, CursorMode.Auto);
		} else if (GameData.Upgrade1Level == 3) {
			Cursor.SetCursor(gold_cursor, Vector2.zero, CursorMode.Auto);
		}
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

		if (GameData.CurrentMoney != prevMoney)
		{
			GameObject tempMoney = Instantiate(floatingText, moneyText.transform);
			tempMoney.GetComponent<FloatUpAndDestroy>().InitialiseText(GameData.CurrentMoney - prevMoney, true);
			prevMoney = GameData.CurrentMoney;
		}

		if (GameData.CurrentEnergy != prevEnergy)
		{
			GameObject tempEnergy = Instantiate(floatingText, energyText.transform);
			tempEnergy.GetComponent<FloatUpAndDestroy>().InitialiseText((GameData.CurrentEnergy - prevEnergy)/GameData.MaxEnergy * 100f, false);
			prevEnergy = GameData.CurrentEnergy;
		}

    }

    public void UnpauseGame() {
        Paused = false;
        pauseMenu.SetActive(false);
    }

    public IEnumerator RestartDay(float percentEnergy) {
        Paused = true;

        GameData.CurrentEnergy = percentEnergy * GameData.MaxEnergy;
        GameData.CurrentDay += 1;
        GameData.SavePlayerData();

        yield return StartCoroutine(fadeScreen.GetComponent<FadeToAlpha>().FadeToBlack());

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
