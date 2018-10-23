using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    Button button;

    public GameObject TooltipUi;
    public TMPro.TextMeshProUGUI TooltipUiText;

    [SerializeField]
    TMPro.TextMeshProUGUI costText;

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
        TooltipUi.SetActive(false);
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

    void UpdateButtonState(int day, int cost) {
        costText.text = "$" + cost.ToString();

        if (GameData.CurrentDay >= day && GameData.CurrentMoney >= cost) {
            button.interactable = true;
            costText.color = Color.green;
        }
        else {
            button.interactable = false;
            costText.color = Color.red;
        }
    }

    public void OnMouseOver() {
        TooltipUi.SetActive(true);

        switch (UpgradeNumber) {
            case (1):
                TooltipUiText.text = "This magical upgrade will click your character so you don't have to!";
                break;
            case (2):
                TooltipUiText.text = "Dress to impress! Increases the amount of money you earn at work.";
                break;
            case (3):
                TooltipUiText.text = "Upgrade your efficiency at work! Increases the amount of money you earn.";
                break;
            case (4):
                TooltipUiText.text = "Travel in luxury! Increases the amount of energy you have.";
                break;
            case (5):
                TooltipUiText.text = "Live in comfort! Increases the amount of energy you have.";
                break;
        }

        TooltipUiText.text += " Upgrades unlock on day " + Level1ActiveDay + ", " + Level2ActiveDay + " & " + Level3ActiveDay;
    }

    public void OnMouseExit() {
        TooltipUi.SetActive(false);
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
