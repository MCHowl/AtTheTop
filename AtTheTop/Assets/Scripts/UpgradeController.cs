using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    Button button;

    [SerializeField]
    int UpgradeNumber;

    [SerializeField]
    int Level1Cost, Level2Cost, Level3Cost;

    [SerializeField]
    int Level1ActiveDay, Level2ActiveDay, Level3ActiveDay;

    int UpgradeLevel;
    bool isUpgradable = true;

    void Start() {
        button = GetComponent<Button>();
    }

    void Update() {
        switch (UpgradeNumber) {
            case (1):
                UpgradeLevel = GameData.Upgrade1Level;
                break;
            case (2):
                UpgradeLevel = GameData.Upgrade2Level;
                break;
            case (3):
                UpgradeLevel = GameData.Upgrade3Level;
                break;
            case (4):
                UpgradeLevel = GameData.Upgrade4Level;
                break;
            case (5):
                UpgradeLevel = GameData.Upgrade5Level;
                break;
        }

        if (isUpgradable) {
            switch (UpgradeLevel) {
                case (0):
                    UpdateButtonState(Level1ActiveDay, Level1Cost);
                    break;
                case (1):
                    UpdateButtonState(Level2ActiveDay, Level2Cost);
                    break;
                case (2):
                    UpdateButtonState(Level2ActiveDay, Level2Cost);
                    break;
                default:
                    isUpgradable = false;
                    break;
            }
        }
    }

    void UpdateButtonState(int day, int cost) {
        if (GameData.CurrentDay >= day && GameData.CurrentMoney >= cost) {
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
    }

    public void Upgrade() {
        switch (UpgradeLevel) {
            case (0):
                GameData.CurrentMoney -= Level1Cost;
                break;
            case (1):
                GameData.CurrentMoney -= Level2Cost;
                break;
            case (2):
                GameData.CurrentMoney -= Level3Cost;
                break;
        }

        switch (UpgradeNumber) {
            case (1):
                GameData.Upgrade1Level++;
                break;
            case (2):
                GameData.Upgrade2Level++;
                break;
            case (3):
                GameData.Upgrade3Level++;
                break;
            case (4):
                GameData.Upgrade4Level++;
                break;
            case (5):
                GameData.Upgrade5Level++;
                break;
        }
    }
}
