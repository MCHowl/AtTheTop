using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWorkCollider : MonoBehaviour {

    bool triggered { get; set; }

    void Start() {
        triggered = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (!triggered) {
            triggered = true;
            GameController.InOffice = true;
        }
    }
}
