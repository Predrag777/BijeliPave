using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] private ParticleSystem attackSystem;
    float attackDuration = 0.6f;
    float distance = 0f;
    Rigidbody rb;
    private Animator animator;

    string[] attacks = { "punch1", "punch2" };
    string[] attacks2 = { "kick1", "kick2" };

    int c = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //attackSystem.Play();
            StartCoroutine(performAttack(attacks));
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(performAttack(attacks2));
        }
    }


    private IEnumerator performAttack(string [] attacks)
    {
        //animator.speed = 2f;

        animator.Play(attacks[c]);


        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * distance;

        float elapsed = 0f;
        while (elapsed < attackDuration)
        {
            rb.MovePosition(Vector3.Lerp(start, end, elapsed / attackDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }
        rb.MovePosition(end);
        animator.speed = 1f;

        c++;
        if (c >= attacks.Length)
            c = 0;
    }
}
