using UnityEngine;

public class CameraFollow : MonoBehaviour
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
    }

    void LateUpdate()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -20f, 60f); 

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = target.position + Vector3.up * height + offset;
        transform.LookAt(target.position + Vector3.up * height);
    }
    public float GetYaw()
    {
        return rotationX;
    }
}
