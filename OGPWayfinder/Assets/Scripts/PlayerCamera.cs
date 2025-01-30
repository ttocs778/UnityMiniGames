using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;

    float rotateX = 0f;
    float rotateY = 90f;
    Transform camPivot;

    public static bool locked;

    void Start()
    {
        camPivot = GetComponentInChildren<Camera>().transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 10 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 10 * Time.deltaTime;

            rotateY += mouseX;
            rotateX -= mouseY;
            rotateX = Mathf.Clamp(rotateX, -90f, 90f);


            camPivot.transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, rotateY, 0f);
        }
    }

    public void SetRotateY(float y)
    {
        rotateY = y;
    }

    public void AddRotateY(float y)
    {
        rotateY += y;
    }
}