using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    [SerializeField]
    KeyCode spawnKey;

    [SerializeField]
    GameObject separator, startRoom, endRoom;

    [SerializeField]
    GameObject[] rooms;

    [SerializeField]
    float separatorLength, roomLength, scale;
    float spawnIncrementLength;
    Vector3 currentSpawnPosition;

    [SerializeField]
    int[] roomOrder;

    Transform roomHolder;

    void Start() {
        roomHolder = new GameObject("Rooms").transform;

        spawnIncrementLength = (separatorLength + roomLength) * scale / 2.0f;
        currentSpawnPosition = new Vector3(0, 0, 0);

        SpawnAllRooms();
    }

    void SpawnAllRooms() {
        currentSpawnPosition.x = -spawnIncrementLength;

        // spawn first separator
        Instantiate(separator, currentSpawnPosition, Quaternion.identity, roomHolder);
        currentSpawnPosition.x += spawnIncrementLength;

        // spawn first room
        SpawnRoom(startRoom);

        // spawn all sandwich rooms
        foreach (int i in roomOrder) {
            SpawnRoom(rooms[i]);
        }

        // spawn last room
        SpawnRoom(endRoom);
    }

    void SpawnRoom(GameObject room) {
        Instantiate(room, currentSpawnPosition, Quaternion.identity, roomHolder);
        currentSpawnPosition.x += spawnIncrementLength;
        Instantiate(separator, currentSpawnPosition, Quaternion.identity, roomHolder);
        currentSpawnPosition.x += spawnIncrementLength;
    }
}
