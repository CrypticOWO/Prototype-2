using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject Player;

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

        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

            // Calculate the final movement vector (normalized)
            Vector3 moveDirection = (forward * direction.z + right * direction.x).normalized;

            RB.linearVelocity = new Vector3(moveDirection.x * HorizontalSpeed, RB.linearVelocity.y, moveDirection.z * HorizontalSpeed);
        }
        else
        {
            RB.linearVelocity = new Vector3(0, RB.linearVelocity.y, 0);
        }
    }
}
