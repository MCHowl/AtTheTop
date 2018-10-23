using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    [SerializeField]
    KeyCode spawnKey;

    [SerializeField]
    GameObject separator, startRoom, officeRoom;

    [SerializeField]
    GameObject[] rooms;

    [SerializeField]
    float roomLength;
    Vector3 currentSpawnPosition;

    [SerializeField]
    int[] roomOrder;

    Transform roomHolder;

    void Start() {
        roomHolder = new GameObject("Rooms").transform;

        currentSpawnPosition = new Vector3(0, 0, 0);

        SpawnAllRooms();
    }

    void SpawnAllRooms() {
        currentSpawnPosition.x = -roomLength;

        // spawn all rooms
        foreach (int i in roomOrder) {
            SpawnRoom(rooms[i]);
        }

        // spawn office
        SpawnRoom(officeRoom);

        // inversely spawn sandwich rooms
        for (int i = roomOrder.Length - 1; i >= 0; i--) {
            SpawnRoom(rooms[roomOrder[i]]);
        }
    }

    void SpawnRoom(GameObject room) {
        Instantiate(room, currentSpawnPosition, Quaternion.identity, roomHolder);
        currentSpawnPosition.x += roomLength;
    }
}
