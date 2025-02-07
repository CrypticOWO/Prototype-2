using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public Transform playerCamera;
    public float rotationSpeed = 5f;
    public ParticleSystem fireEffect;
    public float distanceFromCamera = 2f;
    public float heightOffset = -2f;

    private void Update()
    {
        RotateWithMouse();
        HandleFireEffect();
    }

    void RotateWithMouse()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        // Calculate the desired rotation of the firebreath
        Quaternion horizontalRotation = Quaternion.Euler(0, horizontal * rotationSpeed, 0);
        Quaternion verticalRotation = Quaternion.Euler(-vertical * rotationSpeed + 90, 0, 0);

        // Apply the calculated rotations to the firebreath (relative to the camera's position)
        transform.rotation = playerCamera.rotation * horizontalRotation * verticalRotation;

        Vector3 newPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;
        newPosition.y += heightOffset;
        transform.position = newPosition;
    }

    void HandleFireEffect()
    {
        if (Input.GetMouseButton(0))
        {
            if (!fireEffect.isPlaying)
            {
                fireEffect.Play();
            }
        }
        else
        {
            if (fireEffect.isPlaying)
            {
                fireEffect.Stop();
            }
        }
    }
}
