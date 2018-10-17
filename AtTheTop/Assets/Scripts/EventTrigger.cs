using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public int TriggerDay;
    public string EventText;
    public int EnergyChange, MoneyChange;

    public bool VisibleWhenInactive;

    EventController eventController;
    EventController.Event newEvent;

    void Start() {
        eventController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventController>();
        newEvent = new EventController.Event(EventText, EnergyChange, MoneyChange);

        if (!VisibleWhenInactive && GameData.CurrentDay != TriggerDay) {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (GameData.CurrentDay == TriggerDay) {
            eventController.TriggerEvent(newEvent);
        }
    }
}
