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
                UpdateButtonState(Level3ActiveDay, Level3Cost);
                break;
            default:
                isUpgradable = false;
                costText.text = "";
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
            if (GameData.CurrentMoney >= cost) {
                costText.color = Color.yellow;
            } else {
                costText.color = Color.red;
            }
        }
    }

    public void OnMouseOver() {
        TooltipUi.SetActive(true);

        switch (UpgradeNumber) {
            case (1):
                if (UpgradeLevel == 0) {
                    TooltipUiText.text = "Clicker 1000" + "\n<i>Leave it in our hands... so you don't have to use yours!</i>" + "\nUnlocked on day " + Level1ActiveDay;
                } else if (UpgradeLevel == 1) {
                    TooltipUiText.text = "Clicker 2077" + "\n<i>'More Clicks More Speed' - The Analects of Confuciu$</i>" + "\nUnlocked on day " + Level2ActiveDay;
                } else if (UpgradeLevel == 2) {
                    TooltipUiText.text = "Clicker 3000" + "\n<i>Nothing is free except being hands-free with Clicker 3000</i>" + "\nUnlocked on day " + Level3ActiveDay;
                } else {
                    TooltipUiText.text = "No more upgrades found. Way to go you.\n";
                }
                break;
            case (2):
                if (UpgradeLevel == 0) {
                    TooltipUiText.text = "Navy Blue Shirt" + "\n<i>Gain confidence and show your boss who's boss at work!</i>" + "\nUnlocked on day " + Level1ActiveDay;
                } else if (UpgradeLevel == 1) {
                    TooltipUiText.text = "Midnight Blue Shirt" + "\n<i>Honey, where's my super suit? Oh right, you have no one.</i>" + "\nUnlocked on day " + Level2ActiveDay;
                } else if (UpgradeLevel == 2) {
                    TooltipUiText.text = "Royal Blue Shirt" + "\n<i>Suit yourself. Cause that's all you have.</i>" + "\nUnlocked on day " + Level3ActiveDay;
                } else {
                    TooltipUiText.text = "No more upgrades found. Way to go you.\n";
                }
                break;
            case (3):
                if (UpgradeLevel == 0) {
                    TooltipUiText.text = "Orange Air" + "\n<i>Get your heads out of the clouds and your work in the Air.</i>" + "\nUnlocked on day " + Level1ActiveDay;
                } else if (UpgradeLevel == 1) {
                    TooltipUiText.text = "Orange Pro" + "\n<i>We put the P in Pro... and Price.</i>" + "\nUnlocked on day " + Level2ActiveDay;
                } else if (UpgradeLevel == 2) {
                    TooltipUiText.text = "iOrange" + "\n<i>The 'i' in team is here. iOrange, be you, be alone.</i>" + "\nUnlocked on day " + Level3ActiveDay;
                } else {
                    TooltipUiText.text = "No more upgrades found. Way to go you.\n";
                }
                break;
            case (4):
                if (UpgradeLevel == 0) {
                    TooltipUiText.text = "Doyota" + "\n<i>Your everyday car for the everyday career man/woman.</i>" + "\nUnlocked on day " + Level1ActiveDay;
                } else if (UpgradeLevel == 1) {
                    TooltipUiText.text = "Laxus" + "\n<i>The same thing, just better.</i>" + "\nUnlocked on day " + Level2ActiveDay;
                } else if (UpgradeLevel == 2) {
                    TooltipUiText.text = "Tesla" + "\n<i>Telsa, teleport us to mars. So you can live alone, not like there's any difference now anyway.</i>" + "\nUnlocked on day " + Level3ActiveDay;
                } else {
                    TooltipUiText.text = "No more upgrades found. Way to go you.\n";
                }
                break;
            case (5):
                if (UpgradeLevel == 0) {
                    TooltipUiText.text = "Sea Esta" + "\n<i>East siders' condo of choice!</i>" + "\nUnlocked on day " + Level1ActiveDay;
                } else if (UpgradeLevel == 1) {
                    TooltipUiText.text = "The Life @ Orchard" + "\n<i>Neighbourhood grocery shopping has never been more expensive!</i>" + "\nUnlocked on day " + Level2ActiveDay;
                } else if (UpgradeLevel == 2) {
                    TooltipUiText.text = "Balance! @ CBD" + "\n<i>Live where you work, and you'll never live another day in your life...</i>" + "\nUnlocked on day " + Level3ActiveDay;
                } else {
                    TooltipUiText.text = "No more upgrades found. Way to go you.\n";
                }
                break;
        }
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
