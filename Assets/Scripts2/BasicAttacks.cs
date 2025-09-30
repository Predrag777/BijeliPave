using UnityEngine;
using System.Collections;
public class BasicAttacks : MonoBehaviour
{
    private float damage = 5f;
    private float speed = 1f;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayAttacks());
        }
    }

    private IEnumerator PlayAttacks()
    {
        animator.Play("punch");
        yield return new WaitForSeconds(speed);
    }
}
