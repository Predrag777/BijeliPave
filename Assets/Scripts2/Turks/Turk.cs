using UnityEngine;
using System.Collections;
public class Turk : MonoBehaviour
{
    Animator animator;
    bool isHit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetHited());
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


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("hand") && !isHit)
        {
            Debug.Log("HIT");
            isHit = true;
        }
        
    }

     
}
