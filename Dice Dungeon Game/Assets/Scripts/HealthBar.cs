using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthIcon;
    [SerializeField] private Sprite[] diceFaces;
    [SerializeField] private Animator animator;

    public void UpdateHealth(int health) {
        animator.SetTrigger("Change");
        healthIcon.sprite = diceFaces[health-1];
    }
}
