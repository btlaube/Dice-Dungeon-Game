using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; //0 - Top 1 - Right 2 - Bottom 3 - Left
    public GameObject[] doors;

    [SerializeField] private GameObject enemy;

    public void UpdateRoom(bool[] status) {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }

    public void SpawnEnemies() {
        for (int i = 0; i < Random.Range(2, 11); i++) {
            Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-6, 7), transform.position.y + Random.Range(-3, 4), 0f), Quaternion.identity, transform);
        }
    }
}
