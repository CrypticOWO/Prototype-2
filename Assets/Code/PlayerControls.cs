using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject Player;

    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    float cameraHorizontalRotation = 0f;
    public static float HorizontalSpeed = 15f;

    void Start()
    {
        Player.transform.position = new Vector3(0, 1.5f, 0);
    }

    void Update()
    {
        NormalControls();
    }

    void NormalControls()
    {
        RB.isKinematic = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        cameraHorizontalRotation += inputX;
        Player.transform.localEulerAngles = new Vector3(cameraVerticalRotation, cameraHorizontalRotation, 0);

        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Get the forward and right directions from the camera, ensuring y is zeroed
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

            // Calculate the final movement vector (normalized)
            Vector3 moveDirection = (forward * direction.z + right * direction.x).normalized;

            // Set the velocity directly to move the player with no gradual deceleration
            RB.linearVelocity = new Vector3(moveDirection.x * HorizontalSpeed, RB.linearVelocity.y, moveDirection.z * HorizontalSpeed);
        }
        else
        {
            // If no input, set the velocity to zero on the x and z axes, while maintaining the y velocity (for gravity)
            RB.linearVelocity = new Vector3(0, RB.linearVelocity.y, 0);

            if (!Input.GetKey(KeyCode.LeftControl))
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            }
        }
    }
}
