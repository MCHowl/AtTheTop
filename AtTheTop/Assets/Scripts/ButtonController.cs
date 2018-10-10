using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    Canvas canvas;

	void Start () {
        if (canvas != null) {
            canvas.enabled = false;
        } 
	}

    public void CloseApplication() {
        Application.Quit();
    }

    public void ShowCanvas() {
        canvas.enabled = true;
    }

    public void HideCanvas() {
        canvas.enabled = false;
    }

    public void LoadLevel(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }

    public void StartGame() {
        if (PlayerPrefs.GetInt("character") == 0) {
            ShowCanvas();
        } else {
            LoadLevel(1);
        }
    }

    public void ResetData() {
        PlayerPrefs.DeleteAll();
    }

    public void SetCharacter(int i) {
        PlayerPrefs.SetInt("character", i);
        PlayerPrefs.Save();
        StartGame();
    }
}
