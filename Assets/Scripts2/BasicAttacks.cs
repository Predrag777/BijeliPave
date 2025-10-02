using UnityEngine;
using System.Collections;
public class BasicAttacks : MonoBehaviour
{
    [SerializeField] private ParticleSystem powerUp;
    private float damage = 5f;
    private float speed = 1f;
    private Animator animator;
    private Knight knight;

    public bool isAttacking = false;
    private string[] attacks = { "punch", "punch2" };

    private string[] kickAttacks = { "kick1", "kick2" };


    public GameObject target; 
    int c = 0;
    int c2 = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUp.Stop();
        animator = GetComponent<Animator>();
        knight = GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knight.isSword) return;
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayAttacks());
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(PlayKicks());
        }


        animator.SetBool("fight", isAttacking);
    }

    private IEnumerator PlayAttacks()
    {
        animator.Play(attacks[c]);
        /*powerUp.Play();
        for (int i = 0; i < 3; i++)
        {
            transform.position += transform.forward * 30f * Time.fixedDeltaTime;
            yield return new WaitForSeconds(0.1f);

        }*/
        c++;
        if (c >= attacks.Length)
            c = 0;
        isAttacking = true;
        findNearestTarget();
        yield return new WaitForSeconds(speed);
    }

    private IEnumerator PlayKicks()
    {
        animator.Play(kickAttacks[c]);

        c++;
        if (c >= kickAttacks.Length)
            c = 0;
        isAttacking = true;
        yield return new WaitForSeconds(speed);
    }

    public void findNearestTarget()
    {
        GameObject [] all = GameObject.FindGameObjectsWithTag("enemy");
        float minDist = 99999f;
        for (int i = 0; i < all.Length; i++)
        {
            float currDist = Vector3.Distance(transform.position, all[i].transform.position);
            if (currDist < minDist)
            {
                target = all[i];
                minDist = currDist;
            }
        }
    }


    private IEnumerator refreshAttack()
    {
        yield return new WaitForSeconds(5f);
        isAttacking = false;
    }
}
