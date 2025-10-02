using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 5f;
    GameObject rightArm;
    
    
    public bool isSword = false;
    void Start()
    {
        rightArm = GameObject.Find("rightHand");
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
        
    }
}
