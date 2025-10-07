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

    void Start()
    {
        rightArm = GameObject.Find("rightHand");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health>0)
            StartCoroutine(GetHited());
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

            isSword = true;
        }
        if ((other.gameObject.CompareTag("hand") || other.gameObject.CompareTag("leg")) && !isHit)
        {

            Debug.Log("I am hitted");
            isHit = true;
        }

    }
    
    private IEnumerator GetHited()
    {
        if (isHit)
        {
            animator.Play("hited");
            isHit = false;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0f);
    }
}
