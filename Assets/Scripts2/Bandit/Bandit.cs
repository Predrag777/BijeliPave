using UnityEngine;
using System.Collections;
public class Bandit : MonoBehaviour
{
    public float health = 5f;
    Animator animator;
    bool isHit = false;
    bool isDie = false;

    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
            isDie = true;
        if (!isDie)
                StartCoroutine(GetHited());
            else
            {
                StartCoroutine(Die());
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

    private IEnumerator Die()
    {
        health = 0f;
        animator.Play("death");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("hand") || other.gameObject.CompareTag("leg")) && !isHit)
        {
            Debug.Log("HIT");
            isHit = true;
            isAttacking = true;
            health -= 1f;
        }

        if (other.gameObject.CompareTag("sword"))
        {
            isDie = true;
        }

    }
    

    
}
