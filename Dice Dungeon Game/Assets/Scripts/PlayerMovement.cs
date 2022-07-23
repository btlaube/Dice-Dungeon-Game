using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 input;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
    }
}
