using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int currentHealth;// {get; private set;}

    [SerializeField] private int startingHealth;
    [SerializeField] private HealthBar healthBar;    
    private AudioManager audioManager;

    void Awake() {
        currentHealth = startingHealth;
        healthBar = GameObject.Find("Health").GetComponent<HealthBar>();
    }

    void Start() {
        audioManager = AudioManager.instance;
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.G)) {
            TakeDamage(1);
        }
        if(Input.GetKeyUp(KeyCode.H)) {
            Heal(1);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        audioManager.Play("Hit");
        healthBar.UpdateHealth(currentHealth);
    }

    public void Heal(int amount) {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);
        audioManager.Play("Heal");
        healthBar.UpdateHealth(currentHealth);
    }
}
