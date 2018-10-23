using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {

    private TMPro.TextMeshPro calendarText;

	void Start () {
        calendarText = GetComponent<TMPro.TextMeshPro>();
	}

    private void Update() {
        calendarText.text = GameData.CurrentDay.ToString() + "\nFeb";
    }
}
