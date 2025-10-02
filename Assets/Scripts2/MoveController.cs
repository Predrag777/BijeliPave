using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float sensitivity = 15f;

    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private CameraController cameraFollow; 
    BasicAttacks bAttacks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        bAttacks = GetComponent<BasicAttacks>();
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Quaternion camRotation = Quaternion.Euler(0, cameraFollow.GetYaw(), 0);
        Vector3 move = camRotation * new Vector3(horizontal, 0f, vertical);

        if (move != Vector3.zero)
        {
            animator.SetFloat("speed", speed);

            //if (!bAttacks.isAttacking)
                transform.rotation = Quaternion.LookRotation(move, Vector3.up);
            /*else if(bAttacks.target!=null)
                transform.LookAt(bAttacks.target.transform);*/
            rb.MovePosition(transform.position + move.normalized * Time.fixedDeltaTime * speed);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
    }


    private void Rotation()
    {
        float rotUp = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float rotX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * rotX);
        
    }
}
