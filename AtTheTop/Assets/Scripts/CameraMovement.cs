using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    GameObject player;

    GameObject playerInstance;

    Vector3 offset;

    void Start() {
        playerInstance = Instantiate(player);
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () {
        transform.position = playerInstance.transform.position + offset;
	}
}
