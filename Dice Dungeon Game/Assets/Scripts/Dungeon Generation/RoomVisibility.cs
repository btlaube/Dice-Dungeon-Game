using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisibility : MonoBehaviour
{
    public Transform player;
    public List<Transform> rooms = new List<Transform>();

    private Camera mainCamera;
    private int currentRoom;

    void Awake() {
        mainCamera = Camera.main;
    }

    void Update() {
        UpdateRooms();
    }

    void UpdateRooms() {
        float distance;
        float minDistance = Mathf.Infinity;

        foreach(Transform room in transform) {
            room.gameObject.SetActive(false);
        }

        for (int i = 0; i < rooms.Count; i++) {
            distance = Vector2.Distance(rooms[i].position, player.position);
            if(distance < minDistance) {
                minDistance = distance;
                currentRoom = i;
            }
        }

        transform.GetChild(currentRoom).gameObject.SetActive(true);
        mainCamera.transform.position = new Vector3(transform.GetChild(currentRoom).position.x, transform.GetChild(currentRoom).position.y, mainCamera.transform.position.z);
    }

    public void GetRooms() {
        foreach (Transform child in transform)
        {
            rooms.Add(child);
        }
    }
}
