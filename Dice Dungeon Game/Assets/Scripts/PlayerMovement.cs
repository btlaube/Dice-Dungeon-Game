using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 input;
    [SerializeField] private float moveSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update() {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (input.x > 0.1f) {
            spriteRenderer.flipX = false;
        }
        else if (input.x < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate() {   
        GetComponent<Rigidbody2D>().velocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
    }
}
