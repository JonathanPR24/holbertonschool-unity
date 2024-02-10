using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public float cameraSensitivity = 2f; // Mouse sensitivity for camera rotation
    public float distanceFromPlayer = 6.25f; // Distance between camera and player
    public Vector2 verticalRotationLimits = new Vector2(-90f, 90f); // Limits for vertical rotation

    private float horizontalRotation = 0f; // Current horizontal rotation of the camera
    private float verticalRotation = 0f; // Current vertical rotation of the camera

    void Start()
    {
        // Lock and hide the cursor when right-clicking
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set initial rotation angles
        horizontalRotation = playerTransform.eulerAngles.y;
        verticalRotation = transform.eulerAngles.x;
    }

    void Update()
    {
        // Rotate the player based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity;
        horizontalRotation += mouseX;

        // Rotate the camera vertically based on mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, verticalRotationLimits.x, verticalRotationLimits.y);

        // Calculate camera position based on rotation
        Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
        Vector3 cameraPosition = playerTransform.position - (rotation * Vector3.forward * distanceFromPlayer);

        // Update camera position and rotation
        transform.position = cameraPosition;
        transform.LookAt(playerTransform.position);
    }
}
