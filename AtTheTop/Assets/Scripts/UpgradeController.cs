using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    Button button;

    public GameObject TooltipUi;
    public TMPro.TextMeshProUGUI TooltipUiText;
    public TMPro.TextMeshProUGUI TooltipUiDescription;

    [SerializeField]
    TMPro.TextMeshProUGUI costText;

    [SerializeField]
    int UpgradeNumber;

    [SerializeField]
    int Level1Cost, Level2Cost, Level3Cost;

    int UpgradeLevel;

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
                UpdateButtonState(Level1Cost);
                break;
            case (1):
                UpdateButtonState(Level2Cost);
                break;
            case (2):
                UpdateButtonState(Level3Cost);
                break;
            default:
                button.interactable = false;
                costText.text = "";
                break;
        }

    }

    void UpdateButtonState(int cost) {
        costText.text = "$" + cost.ToString();

        if (GameData.CurrentMoney >= cost) {
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
                if (UpgradeLevel == 0) {
                    if (button.interactable) {
                        TooltipUiText.text = "Clicker 1000: Autoclicks every second";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Leave it in our hands... so you don't have to use yours!\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 1) {
                    if (button.interactable) {
                        TooltipUiText.text = "Clicker 2077: Autoclicks every 0.5 seconds";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>'More Clicks More Speed' - The Analects of Confuciu$\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 2) {
                    if (button.interactable) {
                        TooltipUiText.text = "Clicker 3000: Autoclicks every 0.25 seconds";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Nothing is free except being hands-free with Clicker 3000\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else {
                    TooltipUiText.text = "Maximum upgrade level reached. Way to go you.";
                    TooltipUiDescription.text = "";
                }
                break;
            case (2):
                if (UpgradeLevel == 0) {
                    if (button.interactable) {
                        TooltipUiText.text = "Navy Blue Shirt: Money earned +10%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Gain confidence and show your boss who's boss at work!\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 1) {
                    if (button.interactable) {
                        TooltipUiText.text = "Midnight Blue Shirt: Money earned +15%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Honey, where's my super suit? Oh right, you have no one.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 2) {
                    if (button.interactable) {
                        TooltipUiText.text = "Royal Blue Shirt: Money earned +20%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Suit yourself. Cause that's all you have.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else {
                    TooltipUiText.text = "Maximum upgrade level reached. Way to go you.";
                    TooltipUiDescription.text = "";
                }
                break;
            case (3):
                if (UpgradeLevel == 0) {
                    if (button.interactable) {
                        TooltipUiText.text = "Orange Air: Money earned +20%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Get your heads out of the clouds and your work in the Air.\n</i>";
                    if (button.interactable)
                    {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 1) {
                    if (button.interactable) {
                        TooltipUiText.text = "Orange Air: Money earned +30%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>We put the P in Pro... and Price.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 2) {
                    if (button.interactable) {
                        TooltipUiText.text = "iOrange: Money earned +40%";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>The 'i' in team is here. iOrange, be you, be alone.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else {
                    TooltipUiText.text = "Maximum upgrade level reached. Way to go you.";
                    TooltipUiDescription.text = "";
                }
                break;
            case (4):
                if (UpgradeLevel == 0) {
                    if (button.interactable) {
                        TooltipUiText.text = "Doyota: Clicking efficiency x2";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Your everyday car for the everyday career man/woman.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 1) {
                    if (button.interactable) {
                        TooltipUiText.text = "Laxus: Clicking efficiency x3";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>The same thing, just better.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 2) {
                    if (button.interactable) {
                        TooltipUiText.text = "Laxus: Clicking efficiency x4";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Telsa, teleport us to mars. So you can live alone, not like there's any difference now anyway.\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else {
                    TooltipUiText.text = "Maximum upgrade level reached. Way to go you.";
                    TooltipUiDescription.text = "";
                }
                break;
            case (5):
                if (UpgradeLevel == 0) {
                    if (button.interactable) {
                        TooltipUiText.text = "Sea Esta: Clicking efficiency x2";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>East siders' condo of choice!\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 1) {
                    if (button.interactable) {
                        TooltipUiText.text = "The Life @ Orchard: Clicking efficiency x3";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Neighbourhood grocery shopping has never been more expensive!\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else if (UpgradeLevel == 2) {
                    if (button.interactable) {
                        TooltipUiText.text = "Balance! @ CBD: Clicking efficiency x4";
                    } else {
                        TooltipUiText.text = "???: ?????";
                    }
                    TooltipUiDescription.text = "<i>Live where you work, and you'll never live another day in your life...\n</i>";
                    if (button.interactable) {
                        TooltipUiDescription.text += "Click to purchase";
                    }
                } else {
                    TooltipUiText.text = "Maximum upgrade level reached. Way to go you.";
                    TooltipUiDescription.text = "";
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

        OnMouseExit();
        OnMouseOver();
    }
}
