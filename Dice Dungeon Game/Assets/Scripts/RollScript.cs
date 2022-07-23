using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RollScript : MonoBehaviour
{
    public GameObject[] allDice;
    [SerializeField] private float rollRate = 0.1f;

    void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            StartCoroutine("RollDice");
        }
    }

    public void RollWrapper() {
        StartCoroutine("RollDice");
    }

    private IEnumerator RollDice() {
        foreach (GameObject dice in allDice) {
            dice.GetComponent<DiceScript>().StartCoroutine("Roll");
            yield return new WaitForSeconds(rollRate);
        }        
    }
}
