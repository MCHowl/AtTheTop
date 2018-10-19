using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    public class Event {
        public enum EventType { work, parent, friend };

        public string eventText;
        public EventType eventType;
        public int energyChange, moneyChange;

        public Event(string newEventText, EventType newType, int newEnergyChange, int newMoneyChange) {
            eventText = newEventText;
            eventType = newType;
            energyChange = newEnergyChange;
            moneyChange = newMoneyChange;
        }
    }

    public GameObject EventUi;
    public TMPro.TextMeshProUGUI EventUiText;

    public GameObject ActionCancelledUi;
    public TMPro.TextMeshProUGUI ActionCancelledUiText;

    private string exhaustionText = "You feel exhausted. Time to go home.";
    private string insufficientMoneyText = "You don't have enough money to do this.";
    private string insufficientEnergyText = "You don't have enough energy to do this.";

    Event currentEvent;

    private int eventTimeHigh = (int) (250 * 0.8);
    private int eventTimeLow = (int) (250 * 0.2);

    private int event1Time, event2Time, event3Time;
    private bool event1Triggered, event2Triggered, event3Triggered;

	void Start() {
        EventUi.SetActive(false);
        ActionCancelledUi.SetActive(false);

        event1Time = Random.Range(eventTimeLow, eventTimeHigh);
        event2Time = Random.Range(eventTimeLow, eventTimeHigh);
        event3Time = Random.Range(eventTimeLow, eventTimeHigh);
        event1Triggered = false;
        event2Triggered = false;
        event3Triggered = false;
    }
	
	void Update() {
		if (GameData.CurrentEnergy <= 90 && GameController.InOffice) {
            StartCoroutine(ActionCancelledEvent(exhaustionText));
            GameController.InOffice = false;
        }

        if ((int)GameData.CurrentEnergy == event1Time && !event1Triggered) {
            CreateRandomEvent();
            event1Triggered = true;
        } else if ((int)GameData.CurrentEnergy == event2Time && !event2Triggered) {
            CreateRandomEvent();
            event2Triggered = true;
        } else if ((int)GameData.CurrentEnergy == event3Time && !event3Triggered) {
            CreateRandomEvent();
            event3Triggered = true;
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

        if (GameData.CurrentEnergy + currentEvent.energyChange < 0) {
            StartCoroutine(ActionCancelledEvent(insufficientEnergyText));
        } else if (GameData.CurrentMoney + currentEvent.moneyChange < 0) {
            StartCoroutine(ActionCancelledEvent(insufficientMoneyText));
        } else {
            GameData.CurrentEnergy += currentEvent.energyChange;
            GameData.CurrentMoney += currentEvent.moneyChange;
        }

        GameController.Paused = false;
    }

    public void DeclineEvent() {
        EventUi.SetActive(false);

        if (currentEvent.eventType == Event.EventType.friend) {
            GameData.FriendRelationshipLevel = Mathf.Max(0, GameData.FriendRelationshipLevel - 1);
        } else if (currentEvent.eventType == Event.EventType.parent) {
            GameData.ParentRelationshipLevel = Mathf.Max(0, GameData.ParentRelationshipLevel - 1);
        }

        GameController.Paused = false;
    }

    void CreateRandomEvent() {
        float noEventThreshold = 0.1f + 2 * ( (1f - (float)GameData.ParentRelationshipLevel / 10f) + (1f - (float)GameData.FriendRelationshipLevel / 10f) );
        float parentThreshold = 0;
        float friendThreshold = 0;

        if (GameController.InOffice) {
            parentThreshold = (float)GameData.ParentRelationshipLevel / 10f * 0.2f;
            friendThreshold = (float)GameData.FriendRelationshipLevel / 10f * 0.2f + parentThreshold;
        } else {
            if (Random.value <= noEventThreshold) {
                return;
            } else {
                parentThreshold = (float)GameData.ParentRelationshipLevel / 10f * 0.5f;
                friendThreshold = (float)GameData.FriendRelationshipLevel / 10f * 0.5f + parentThreshold;
            }
        }

        float eventTypeRoll = Random.value;
        if (eventTypeRoll <= parentThreshold) {
            TriggerEvent(EventList.ParentEventList[Random.Range(0, EventList.ParentEventList.Count)]);
        } else if (eventTypeRoll <= friendThreshold) {
            TriggerEvent(EventList.FriendEventList[Random.Range(0, EventList.FriendEventList.Count)]);
        } else {
            TriggerEvent(EventList.WorkEventList[Random.Range(0, EventList.WorkEventList.Count)]);
        }
    }

    IEnumerator ActionCancelledEvent(string UiText) {
        ActionCancelledUiText.text = UiText;
        ActionCancelledUi.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        ActionCancelledUi.SetActive(false);
    }
}
