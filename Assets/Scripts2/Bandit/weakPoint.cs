using UnityEngine;
using System.Collections;

public class WeakPoint : MonoBehaviour
{
    public float health = 5f;
    Animator animator;
    bool isHit = false;
    bool isDie = false;

    public bool isAttacking = false;

    AudioSource aSource;
    [SerializeField] AudioClip getPunched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        aSource = GetComponent<AudioSource>();
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
        Destroy(transform.root.gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("hand") || other.gameObject.CompareTag("leg")) && !isHit)
        {
            
            aSource.clip = getPunched;
            aSource.Play();
            isHit = true;
            isAttacking = true;
            health -= 1f;
        }

        if (other.gameObject.CompareTag("sword"))
        {
            Sword sw = other.gameObject.GetComponent<Sword>();
            if(!sw.isFree)
                isDie = true;
        }

    }
}
