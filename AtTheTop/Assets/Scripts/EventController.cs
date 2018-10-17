using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    public class Event {
        public string eventText;
        public int energyChange, moneyChange;

        public Event(string newEventText, int newEnergyChange, int newMoneyChange) {
            eventText = newEventText;
            energyChange = newEnergyChange;
            moneyChange = newMoneyChange;
        }
    }

    public GameObject EventUi;
    public TMPro.TextMeshProUGUI EventUiText;

    Event currentEvent;

	void Start() {
        EventUi.SetActive(false);
	}
	
	void Update() {
		if (GameData.CurrentEnergy <= 100 && GameController.InOffice) {
            print("You feel exhausted. Time to go home.");
            GameController.InOffice = false;
        }
	}

    public void TriggerEvent(Event newEvent) {
        GameController.Paused = true;
        EventUi.SetActive(true);
        currentEvent = newEvent;

        EventUiText.text = currentEvent.eventText;

        if (currentEvent.energyChange > 0) {
            EventUiText.text += "\nEnergy +" + currentEvent.energyChange;
        } else if (currentEvent.energyChange < 0) {
            EventUiText.text += "\nEnergy" + currentEvent.energyChange;
        }

        if (currentEvent.moneyChange > 0) {
            EventUiText.text += "\nMoney +" + currentEvent.moneyChange;
        } else if (currentEvent.moneyChange < 0) {
            EventUiText.text += "\nMoney " + currentEvent.moneyChange;
        }
    }

    public void AcceptEvent() {
        EventUi.SetActive(false);

        GameData.CurrentEnergy += currentEvent.energyChange;
        GameData.CurrentMoney += currentEvent.moneyChange;

        GameController.Paused = false;
    }

    public void DeclineEvent() {
        EventUi.SetActive(false);
        GameController.Paused = false;
    }
}
