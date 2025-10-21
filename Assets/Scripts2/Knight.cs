using UnityEngine;
using System.Collections;
public class Knight : MonoBehaviour
{
    public float speed = 5f;
    GameObject rightArm;

    public float health = 5f;
    public bool isSword = false;
    bool isHit;
    Animator animator;
    GameObject respawnPos;
    public bool isBlock = false;


    GameObject sword;

    [SerializeField] GameObject leftHand;
    [SerializeField]  GameObject rightHand;
    [SerializeField]  GameObject weakPoint;

    AudioSource aSource;
    [SerializeField] AudioClip getPunched;
    void Start()
    {
        rightArm = GameObject.Find("rightHand");

        animator = GetComponent<Animator>();
        respawnPos = GameObject.Find("RespawnPos");
        aSource = GetComponent<AudioSource>();

        /*leftHand = GameObject.Find("leftHand");
        rightHand = GameObject.Find("rightHand");
        weakPoint = GameObject.Find("mixamorig:Spine2");*/
    }

    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(PlayerDeathSequence());
        }
        if (health > 0)
            StartCoroutine(GetHited());

        if (health > 0)
        {
            if (Input.GetKey(KeyCode.G))
            {
                animator.SetBool("block", true);
                isBlock = true;

                leftHand.GetComponent<BoxCollider>().enabled = false;
                rightHand.GetComponent<BoxCollider>().enabled = false;
                weakPoint.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                isBlock = false;
                animator.SetBool("block", false);

                leftHand.GetComponent<BoxCollider>().enabled = true;
                rightHand.GetComponent<BoxCollider>().enabled = true;
                weakPoint.GetComponent<BoxCollider>().enabled = true;

            }
        }

        if (isBlock)
        {

        }
        if (isSword)
        {
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            GameObject sword = collision.gameObject;

            sword.transform.SetParent(rightArm.transform);

            sword.transform.localPosition = Vector3.zero;
            sword.transform.localRotation = Quaternion.identity;

            Rigidbody rb = sword.GetComponent<Rigidbody>();

            isSword = true;
        }
    }

    /*private IEnumerator GetHited()
    {
        if (isHit)
        {
            health = -1f;
            animator.Play("hited");
            isHit = false;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0f);
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            GameObject sword = other.gameObject;

            sword.transform.SetParent(rightArm.transform);

            sword.transform.localPosition = Vector3.zero;
            sword.transform.localRotation = Quaternion.identity;

            Rigidbody rb = sword.GetComponent<Rigidbody>();
            sword.GetComponent<Sword>().isFree = false;
            isSword = true;
        }
        /*if ((other.gameObject.CompareTag("hand") || other.gameObject.CompareTag("leg")) && !isHit)
        {

            Debug.Log("I am hitted");
            isHit = true;
            health -= 3f;
        }*/
    }


    private IEnumerator GetHited()
    {
        if (isHit)
        {
            aSource.clip = getPunched;
            aSource.Play();
            animator.Play("hited");
            isHit = false;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0f);
    }

    private IEnumerator PlayerDeathSequence()
    {
        animator.Play("death");
        yield return new WaitForSeconds(2f);
        health = 5f;
        Debug.Log("RESPAWN");
        transform.position = respawnPos.transform.position;
    }
}
