using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public List<Transform> rooms = new List<Transform>();
    public List<RoomBehaviour> roomBehaviours = new List<RoomBehaviour>();

    private int currentRoom = 0;
    private int previousRoom = 0;
    private CanvasGroupScript canvasGroupScript;

    void Start() {
        canvasGroupScript = CanvasGroupScript.instance;
    }

    void Update() {
        previousRoom = currentRoom;
        currentRoom = GetCurrentRoom();
        Debug.Log("Current room: " + currentRoom);

        if(currentRoom != previousRoom) {
            RoomChange();
        }
    }

    public void GetRooms() {
        foreach (Transform child in transform)
        {
            rooms.Add(child);
            roomBehaviours.Add(child.GetComponent<RoomBehaviour>());
        }
    }

    public void RoomChange() {
        Debug.Log("Room changed from " + previousRoom + " to " + currentRoom);
        //Player just collided with door (to enter next room)
        //If the room has NOT been "Rolled" already]
        if(!roomBehaviours[currentRoom].loaded) {
            Debug.Log("Room #" + currentRoom + " has NOT been loaded");
        }
        else {
            Debug.Log("Room #" + currentRoom + " has been loaded");
        }
        //Display Roll Canvas
        canvasGroupScript.ShowRollCanvas();
        //Player rolls dice and spends them
        //Player selects "continue" to lock in their choices
        //Read in room attributes
        //Load contents of next room
        //Hide Roll Canvas
        //Move Camera
        //UpdateRoom visibility
        //rollCanvas.SetActive(true);

    }

    public int GetCurrentRoom() {
        float distance;
        float minDistance = Mathf.Infinity;
        int currentRoom = 0;

        for (int i = 0; i < rooms.Count; i++) {
            distance = Vector2.Distance(rooms[i].position, player.position);
            if(distance < minDistance) {
                minDistance = distance;
                currentRoom = i;
            }
        }
        return currentRoom;
    }
}
