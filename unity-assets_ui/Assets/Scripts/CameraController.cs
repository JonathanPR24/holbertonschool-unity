using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraSensitivity = 2f;
    public float distanceFromPlayer = 6.25f;
    public Vector2 verticalRotationLimits = new Vector2(-90f, 90f);
    public bool isInverted = false; // Variable to control Y-axis inversion

    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        horizontalRotation = playerTransform.eulerAngles.y;
        verticalRotation = transform.eulerAngles.x;
    }

    void Update()
    {
        if (Time.timeScale != 0f)
        {
            float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity;
            horizontalRotation += mouseX;

            float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;

            // Check if Y axis should be inverted
            if (isInverted)
                mouseY *= -1; // Invert Y-axis movement

            // Update vertical rotation based on Y-axis movement
            verticalRotation += mouseY;

            // Clamp vertical rotation within specified limits
            verticalRotation = Mathf.Clamp(verticalRotation, verticalRotationLimits.x, verticalRotationLimits.y);

            // Create rotation quaternion based on vertical and horizontal rotation
            Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);

            // Calculate camera position relative to player using rotation and distance
            Vector3 cameraPosition = playerTransform.position - (rotation * Vector3.forward * distanceFromPlayer);

            // Set camera position and make it look at the player
            transform.position = cameraPosition;
            transform.LookAt(playerTransform.position);
        }
    }
}
