using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float rotationSmoothTime = .1f;

    float xRotation = 0f;
    Vector2 currentRotation;
    Vector2 rotationVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Vector2 targetRotation = new Vector2(-mouseY, mouseX);
        currentRotation = Vector2.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, rotationSmoothTime);

        xRotation += currentRotation.x;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * currentRotation.y);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
