using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGroupScript : MonoBehaviour
{
    public static CanvasGroupScript instance;

    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void ShowRollCanvas() {
        foreach(Transform canvas in transform) {
            canvas.gameObject.SetActive(false);
        }
        transform.GetChild(1).gameObject.SetActive(true);
    }

}