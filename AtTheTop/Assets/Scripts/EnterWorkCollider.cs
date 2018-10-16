using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWorkCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameController.InOffice = true;
        }
    }
}
