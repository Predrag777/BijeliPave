using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;  
    [SerializeField] float sensitivity = 3f;
    [SerializeField] float distance = 5f;
    [SerializeField] float height = 1.5f;
    
    private float rotationX;
    private float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -20f, 60f);

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        transform.position = target.position + Vector3.up * height;

        Transform cam = GetComponentInChildren<Camera>().transform;
        cam.localPosition = new Vector3(0, 0, -distance);
    }

    public float GetYaw()
    {
        return rotationX;
    }
}
