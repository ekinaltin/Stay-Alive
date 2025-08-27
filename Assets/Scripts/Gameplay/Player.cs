using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.player = gameObject;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, playerDirection.y * playerSpeed);
    }

    public void UpMovement()
    {
        playerDirection = new Vector2(0f, 1f);
    }
    public void DownMovement()
    {
        playerDirection = new Vector2(0f, -1f);
    }

    public void ResetMovement()
    {
        playerDirection = Vector2.zero;
    }

}
