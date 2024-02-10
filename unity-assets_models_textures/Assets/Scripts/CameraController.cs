using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public float cameraSensitivity = 2f; // Mouse sensitivity for camera rotation
    public Vector3 offset = new Vector3(0f, 2.5f, -6.25f); // Offset from the player's position

    private float cameraRotationX = 0f; // Current X rotation of the camera

    void Start()
    {
        // Lock and hide the cursor when right-clicking
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Camera following
        transform.position = playerTransform.position + offset;

        // Camera rotation with mouse
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            // Rotate the player based on mouse movement
            float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity;
            playerTransform.Rotate(Vector3.up * mouseX);

            // Rotate the camera vertically based on mouse movement
            float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;
            cameraRotationX -= mouseY;
            cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f); // Clamp vertical rotation
            transform.localRotation = Quaternion.Euler(cameraRotationX, playerTransform.eulerAngles.y, 0f);
        }
    }
}
