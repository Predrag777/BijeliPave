using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float sprintSpeed = 7f;
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private CameraFollow cameraFollow; 

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMove();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.Play("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }*/
    }

    void HandleMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Quaternion camRotation = Quaternion.Euler(0, cameraFollow.GetYaw(), 0);
        Vector3 move = camRotation * new Vector3(horizontal, 0f, vertical);

        if (move != Vector3.zero)
        {
            animator.SetFloat("speed", speed);

            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);

            rb.MovePosition(transform.position + move.normalized * Time.fixedDeltaTime * speed);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
