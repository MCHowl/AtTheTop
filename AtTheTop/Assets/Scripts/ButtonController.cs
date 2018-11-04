using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    Canvas canvas;

	[SerializeField]
	Image introImage;

	void Start () {
        if (canvas != null) {
            canvas.enabled = false;
        } 
		if (introImage != null) {
			introImage.enabled = false;
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
			StartCoroutine(IntroScene());
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

	IEnumerator IntroScene() {
		introImage.enabled = true;
		while (introImage.color.a < 1) {
			Color imageColor = introImage.color;
			imageColor.a = introImage.color.a + Time.deltaTime / 5f;
			introImage.color = imageColor;
			yield return null;
		}
		LoadLevel(1);
		yield return null;
	}
}
