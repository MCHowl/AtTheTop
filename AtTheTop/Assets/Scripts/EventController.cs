using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    public class Event {
        public enum EventType { work, parent, friend };

        public string eventText;
        public EventType eventType;
        public float energyChange, moneyChange;

        public Event(string newEventText, EventType newType, float newEnergyChange, float newMoneyChange) {
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

	public GameObject AcceptButton;
	public GameObject DeclineButton;

    public AudioSource eventTriggeredSound;
    private GameController gameController;

    private string dayOverText = "You are overcome with exhaustion.\nEnergy -15% Money -30%";
    private string exhaustionText = "You feel tired. Time to go home.";
    private string insufficientMoneyText = "You don't have enough money to do this.";
    private string insufficientEnergyText = "You don't have enough energy to do this.";

    Event currentEvent;

	private int eventTimeHigh;
    private int eventTimeLow;

    private int event1Time, event2Time, event3Time, event4Time, event5Time, event6Time, event7Time;
    private bool event1Triggered, event2Triggered, event3Triggered, event4Triggered, event5Triggered, event6Triggered, event7Triggered;

	void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        EventUi.SetActive(false);
        ActionCancelledUi.SetActive(false);

		print(GameData.RelationshipLevel);

		eventTimeHigh = (int) (GameData.MaxEnergy * 0.85f);
		eventTimeLow = (int) (GameData.MaxEnergy * 0.15f);

        event1Time = Random.Range(eventTimeLow, eventTimeHigh);
        event2Time = Random.Range(eventTimeLow, eventTimeHigh);
        event3Time = Random.Range(eventTimeLow, eventTimeHigh);
		event4Time = Random.Range(eventTimeLow, eventTimeHigh);
		event5Time = Random.Range(eventTimeLow, eventTimeHigh);
		//event6Time = Random.Range(eventTimeLow, eventTimeHigh);
		//event7Time = Random.Range(eventTimeLow, eventTimeHigh);
		event1Triggered = false;
        event2Triggered = false;
        event3Triggered = false;
        event4Triggered = false;
        event5Triggered = false;
        //event6Triggered = false;
        //event7Triggered = false;
    }
	
	void Update() {
		if (GameData.CurrentEnergy/GameData.MaxEnergy <= 0.225 && GameController.InOffice) {
            StartCoroutine(ActionCancelledEvent(exhaustionText));
            GameController.InOffice = false;
        }

        if (GameData.CurrentEnergy <= 0) {
            StartCoroutine(ActionCancelledEvent(dayOverText));
            StartCoroutine(gameController.RestartDay(0.85f));
			GameData.CurrentMoney *= 0.7f;
        }

        if ((int)GameData.CurrentEnergy == event1Time && !event1Triggered && !EventUi.activeSelf) {
            CreateRandomEvent();
            event1Triggered = true;
        } else if ((int)GameData.CurrentEnergy == event2Time && !event2Triggered && !EventUi.activeSelf) {
            CreateRandomEvent();
            event2Triggered = true;
        } else if ((int)GameData.CurrentEnergy == event3Time && !event3Triggered && !EventUi.activeSelf) {
            CreateRandomEvent();
            event3Triggered = true;
        } else if ((int)GameData.CurrentEnergy == event4Time && !event4Triggered && !EventUi.activeSelf) {
			CreateRandomEvent();
			event4Triggered = true;
		} else if ((int)GameData.CurrentEnergy == event5Time && !event5Triggered && !EventUi.activeSelf) {
			CreateRandomEvent();
			event5Triggered = true;
		}/* else if ((int)GameData.CurrentEnergy == event6Time && !event6Triggered && !EventUi.activeSelf) {
			CreateRandomEvent();
			event6Triggered = true;
		} else if ((int)GameData.CurrentEnergy == event7Time && !event7Triggered && !EventUi.activeSelf) {
			CreateRandomEvent();
			event7Triggered = true;
		}*/
	}

    public void TriggerEvent(Event newEvent) {
        GameController.Paused = true;
        EventUi.SetActive(true);
        eventTriggeredSound.Play();

        currentEvent = newEvent;
        EventUiText.text = currentEvent.eventText;

        if (currentEvent.energyChange > 0) {
            EventUiText.text += "\nEnergy +" + currentEvent.energyChange + "%";
        } else if (currentEvent.energyChange < 0) {
            EventUiText.text += "\nEnergy " + currentEvent.energyChange + "%";
        }

        if (currentEvent.moneyChange > 0) {
            EventUiText.text += "\nMoney +" + currentEvent.moneyChange;
        } else if (currentEvent.moneyChange < 0) {
            EventUiText.text += "\nMoney " + currentEvent.moneyChange;
        }
    }

    public void AcceptEvent() {
        if (GameData.CurrentEnergy + (currentEvent.energyChange * GameData.MaxEnergy / 100) < 0) {
            StartCoroutine(ActionCancelledEvent(insufficientEnergyText));
			DeclineEvent();
			return;
        } else if (GameData.CurrentMoney + currentEvent.moneyChange < 0) {
            StartCoroutine(ActionCancelledEvent(insufficientMoneyText));
			DeclineEvent();
			return;
		} else {
            GameData.CurrentEnergy += currentEvent.energyChange * GameData.MaxEnergy / 100;
            GameData.CurrentMoney += currentEvent.moneyChange;
        }

		if (currentEvent.eventType == Event.EventType.parent) {
			StartCoroutine(EventResponse(EventResponseList.ParentAcceptResponse[Random.Range(0, EventResponseList.ParentAcceptResponse.Count)]));
		} else if (currentEvent.eventType == Event.EventType.friend){
			StartCoroutine(EventResponse(EventResponseList.FriendAcceptResponse[Random.Range(0,EventResponseList.FriendAcceptResponse.Count)]));
		} else {
			EventUi.SetActive(false);
			GameController.Paused = false;
		}
    }

    public void DeclineEvent() {
		//if (currentEvent.eventType == Event.EventType.friend) {
		//    GameData.FriendRelationshipLevel = Mathf.Max(0, GameData.FriendRelationshipLevel - 1);
		//} else if (currentEvent.eventType == Event.EventType.parent) {
		//    GameData.ParentRelationshipLevel = Mathf.Max(0, GameData.ParentRelationshipLevel - 1);
		//}

		if (currentEvent.eventType == Event.EventType.parent) {
			GameData.RelationshipLevel = Mathf.Max(0, GameData.RelationshipLevel - 1);
			StartCoroutine(EventResponse(EventResponseList.ParentDeclineResponse[Random.Range(0, EventResponseList.ParentDeclineResponse.Count)]));
		} else if (currentEvent.eventType == Event.EventType.friend) {
			GameData.RelationshipLevel = Mathf.Max(0, GameData.RelationshipLevel - 1);
			StartCoroutine(EventResponse(EventResponseList.FriendDeclineResponse[Random.Range(0, EventResponseList.FriendDeclineResponse.Count)]));
		} else {
			EventUi.SetActive(false);
			GameController.Paused = false;
		}
	}

    void CreateRandomEvent() {
		//float noEventThreshold = 0.1f + 2 * ( (1f - (float)GameData.ParentRelationshipLevel / 10f) + (1f - (float)GameData.FriendRelationshipLevel / 10f) );
		float relationshipThreshold = 0;
		//float parentThreshold = 0;
        //float friendThreshold = 0;

        /*if (GameController.InOffice) {
			
            parentThreshold = ((float)GameData.ParentRelationshipLevel / 10f) * 0.5f;
            friendThreshold = ((float)GameData.FriendRelationshipLevel / 10f) * 0.5f + parentThreshold;
        } else {
            if (Random.value <= noEventThreshold) {
                return;
            } else {
                parentThreshold = ((float)GameData.ParentRelationshipLevel / 10f) * 0.5f;
                friendThreshold = ((float)GameData.FriendRelationshipLevel / 10f) * 0.5f + parentThreshold;
            }
        }*/

		relationshipThreshold = ((float)GameData.RelationshipLevel / 10f);

		float eventTypeRoll = Random.value;
		/*if (eventTypeRoll <= parentThreshold) {
		    TriggerEvent(EventList.ParentEventList[Random.Range(0, EventList.ParentEventList.Count)]);
		} else if (eventTypeRoll <= friendThreshold) {
		    TriggerEvent(EventList.FriendEventList[Random.Range(0, EventList.FriendEventList.Count)]);
		} else {
		    TriggerEvent(EventList.WorkEventList[Random.Range(0, EventList.WorkEventList.Count)]);
		}*/
		if (eventTypeRoll <= relationshipThreshold / 2) {
			TriggerEvent(EventList.ParentEventList[Random.Range(0, EventList.ParentEventList.Count)]);
		} else if (eventTypeRoll <= relationshipThreshold) {
			TriggerEvent(EventList.FriendEventList[Random.Range(0, EventList.FriendEventList.Count)]);
		} else {
			TriggerEvent(EventList.WorkEventList[Random.Range(0, EventList.WorkEventList.Count)]);
		}
    }

    IEnumerator ActionCancelledEvent(string UiText) {
        ActionCancelledUiText.text = UiText;
        ActionCancelledUi.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ActionCancelledUi.SetActive(false);
    }

	IEnumerator EventResponse(string UiText) {
		GameController.Paused = false;
		AcceptButton.SetActive(false);
		DeclineButton.SetActive(false);
		EventUiText.text = UiText;
		yield return new WaitForSeconds(1.5f);
		AcceptButton.SetActive(true);
		DeclineButton.SetActive(true);
		EventUi.SetActive(false);
	}
}
