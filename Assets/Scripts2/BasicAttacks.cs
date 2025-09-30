using UnityEngine;
using System.Collections;
public class BasicAttacks : MonoBehaviour
{
    [SerializeField] private ParticleSystem powerUp;
    private float damage = 5f;
    private float speed = 1f;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUp.Stop();
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
        powerUp.Play();
        for (int i = 0; i < 3; i++)
        {
            transform.position += transform.forward * 30f * Time.fixedDeltaTime;
            yield return new WaitForSeconds(0.1f);

        }
        yield return new WaitForSeconds(speed);
    }
}
