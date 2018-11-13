using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] rooms;

    [SerializeField]
    float roomLength;
    Vector3 currentSpawnPosition;

    [SerializeField]
    int[] hdbRoomOrder, cbdRoomOrder;

    Transform roomHolder;

	public void InitialiseRooms() {
		roomHolder = new GameObject("Rooms").transform;
		currentSpawnPosition = new Vector3(0, 0, 0);

		SpawnAllRooms();
	}

    void SpawnAllRooms() {
        currentSpawnPosition.x = -roomLength;

        // spawn all rooms
        if (GameData.Upgrade5Level <= 1) {
            foreach (int i in hdbRoomOrder) {
                SpawnRoom(rooms[i]);
            }
        } else {
            foreach (int i in cbdRoomOrder) {
                SpawnRoom(rooms[i]);
            }
        }
        
    }

    void SpawnRoom(GameObject room) {
        Instantiate(room, currentSpawnPosition, Quaternion.identity, roomHolder);
        currentSpawnPosition.x += roomLength;
    }
}
