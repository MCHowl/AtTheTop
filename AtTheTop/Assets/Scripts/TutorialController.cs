using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public bool appearOnMoney;
    public bool appearOnEnergy;
    public bool appearOnWork;

    public int moneyShowLimit;
    public int moneyShowDuration;
    public float energyShowLimit;
    public float energyHideLimit;
    public int workHideLimit;

    bool triggered = false;
    public GameObject tutorialObject;

	void Start () {
        tutorialObject.SetActive(false);
	}
	
	void Update () {
        if (GameData.CurrentDay == 1) {
            if (appearOnMoney && GameData.CurrentMoney >= moneyShowLimit && !triggered) {
                triggered = true;
                StartCoroutine(ShowThenHide());
            }

            if (appearOnEnergy && (GameData.CurrentEnergy / GameData.MaxEnergy) <= energyShowLimit && !triggered) {
                triggered = true;
                tutorialObject.SetActive(true);
            }

            if (appearOnEnergy && (GameData.CurrentEnergy/GameData.MaxEnergy) <= energyHideLimit && triggered) {
                tutorialObject.SetActive(false);
            }

            if (appearOnWork && GameController.InOffice && !triggered) {
                triggered = true;
                tutorialObject.SetActive(true);
            }

            if (appearOnWork && TaskController.WorkDone >= workHideLimit && triggered) {
                tutorialObject.SetActive(false);
            }
        }

	}

    IEnumerator ShowThenHide() {
        tutorialObject.SetActive(true);
        yield return new WaitForSeconds(moneyShowDuration);
        tutorialObject.SetActive(false);
    }
}
