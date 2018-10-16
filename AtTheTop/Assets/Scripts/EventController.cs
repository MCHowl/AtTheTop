using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    [SerializeField]
    GameObject EventUI;

	// Use this for initialization
	void Start () {
        EventUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameData.CurrentEnergy <= 100 && GameController.InOffice) {
            print("You feel exhausted. Time to go home.");
            GameController.InOffice = false;
        }
	}
}
