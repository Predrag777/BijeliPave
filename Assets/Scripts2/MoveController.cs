using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float sensitivity = 15f;

    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private CameraFollow cameraFollow; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float vMove = Input.GetAxis("Vertical");
        float hMove = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(hMove, 0f, vMove) * speed * Time.fixedDeltaTime;
        if (move != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(move);
            
            animator.SetFloat("speed", speed);

            rb.MovePosition(transform.position + move);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }

    private void Rotation()
    {
        float rotUp = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float rotX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * rotX);
        
    }
}
