using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    GameObject player;

    GameObject playerInstance;

    Vector3 cameraPosition;

    void Start() {
        playerInstance = Instantiate(player);
        cameraPosition = new Vector3(0f, 0f, -10f);
    }

    void LateUpdate () {
        cameraPosition.x = playerInstance.transform.position.x;
        transform.position = cameraPosition;
	}
}
