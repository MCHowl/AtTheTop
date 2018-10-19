using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public int TriggerDay;
    public string EventText;
    public EventController.Event.EventType Type;
    public int EnergyChange, MoneyChange;

    public bool VisibleWhenInactive;

    EventController eventController;
    EventController.Event newEvent;

    public bool triggered { get; set; }

    void Start() {
        triggered = false;

        eventController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventController>();
        newEvent = new EventController.Event(EventText, Type, EnergyChange, MoneyChange);

        if (!VisibleWhenInactive && GameData.CurrentDay != TriggerDay) {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (GameData.CurrentDay == TriggerDay && !triggered) {
            triggered = true;
            eventController.TriggerEvent(newEvent);
        }
    }
}
