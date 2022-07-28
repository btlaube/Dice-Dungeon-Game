using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisibility : MonoBehaviour
{
    public Transform player;
    public List<Transform> rooms = new List<Transform>();

    private Camera mainCamera;
    private int currentRoom;
    [SerializeField] private AudioManager audioManager;

    void Awake() {
        mainCamera = Camera.main;
    }

    void Start() {
        audioManager = AudioManager.instance;

        UpdateRooms(0);
    }

    void Update() {
        float distance;
        float minDistance = Mathf.Infinity;
        int previousRoom = currentRoom;

        for (int i = 0; i < rooms.Count; i++) {
            distance = Vector2.Distance(rooms[i].position, player.position);
            if(distance < minDistance) {
                minDistance = distance;
                currentRoom = i;
            }
        }

        if(currentRoom != previousRoom) {
            UpdateRooms(currentRoom);
        }
    }

    void UpdateRooms(int activeRoomIndex) {
        foreach(Transform room in transform) {
            room.gameObject.SetActive(false);
        }

        GameObject activeRoom = transform.GetChild(activeRoomIndex).gameObject;
        activeRoom.SetActive(true);
        mainCamera.transform.position = new Vector3(transform.GetChild(activeRoomIndex).position.x, transform.GetChild(activeRoomIndex).position.y, mainCamera.transform.position.z);
        Debug.Log("updated room");

        audioManager.Play("Door");
        activeRoom.GetComponent<RoomBehaviour>().SpawnEnemies();
    }

    public void GetRooms() {
        foreach (Transform child in transform)
        {
            rooms.Add(child);
        }
    }
}
