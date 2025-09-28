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
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // prikupljanje inputa sa miša
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -20f, 60f);

        // rotacija samog pivot objekta
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // pivot prati viteza po poziciji
        transform.position = target.position + Vector3.up * height;

        // kamera je dete pivota, pa će orbitirati automatski
        Transform cam = GetComponentInChildren<Camera>().transform;
        cam.localPosition = new Vector3(0, 0, -distance);
    }

    // yaw vrednost za viteza
    public float GetYaw()
    {
        return rotationX;
    }
}
