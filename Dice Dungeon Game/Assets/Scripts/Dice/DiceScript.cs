using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    [SerializeField] private Sprite[] faces;
    [SerializeField] private float rollDuration = 2f;
    [SerializeField] private float faceDuration = 0.1f;
    [SerializeField] private Sound rollSound;
    private Image image;

    void Awake() {
        image = GetComponent<Image>();

        
        rollSound.source = gameObject.AddComponent<AudioSource>();
        rollSound.source.clip = rollSound.clip;

        rollSound.source.volume = rollSound.volume;
        rollSound.source.pitch = rollSound.pitch;
        rollSound.source.loop = rollSound.loop;
    }
    
    private IEnumerator Roll() {
        rollSound.source.Play();
        InvokeRepeating("ChangeFace", faceDuration, faceDuration);
        yield return new WaitForSeconds(rollDuration);
        rollSound.source.Stop();
        CancelInvoke("ChangeFace");
    }

    public void ChangeFace() {
        int newFace = Random.Range(0, 6);
        image.sprite = faces[newFace];
    }
}
