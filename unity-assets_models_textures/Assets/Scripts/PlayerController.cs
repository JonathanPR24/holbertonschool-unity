using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform respawnPosition; // The position where the player will respawn
    public float respawnYThreshold = -10f; // Y position threshold for respawn

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get the forward direction of the camera
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Keep the direction horizontal

        // Calculate movement direction based on camera forward and player input
        Vector3 movement = (cameraForward * verticalInput + Camera.main.transform.right * horizontalInput).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Handle player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Check if the player's Y position falls below the respawn threshold
        if (transform.position.y < respawnYThreshold)
        {
            Respawn();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Respawn()
    {
        // Move the player to the respawn position
        transform.position = respawnPosition.position;
        rb.velocity = Vector3.zero; // Reset velocity
    }
}
