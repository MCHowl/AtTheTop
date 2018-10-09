using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    bool isInGame = false;
    bool isPaused = true;

    // Properties
    public bool InGame {
        get { return isInGame; }
        set { isInGame = value; }
    }

    public bool Paused {
        get { return isPaused; }
        set { isPaused = value; }
    }

    // Listeners
    private void OnEnable() {
        ScreenFade.DayEndEvent += RestartDay;
    }

    private void OnDisable()
    {
        ScreenFade.DayEndEvent -= RestartDay;
    }

    // Game Management
    public void RestartDay() {
        print("Hi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
