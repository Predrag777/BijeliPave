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
    public GameObject target;

    private string[] attacks = { "punch", "punch2" };
    private string[] kickAttacks = { "kick1", "kick2" };
    int c = 0;
    int c2 = 0;

    void Start()
    {
        powerUp.Stop();
        animator = GetComponent<Animator>();
        knight = GetComponent<Knight>();
    }

    void Update()
    {
        if (knight.health <= 0f) return;
        if (knight.isSword) return;
        if (isAttacking) return;

        if (Input.GetMouseButtonDown(0))
            StartCoroutine(PlayAttacks());
        if (Input.GetMouseButtonDown(1))
            StartCoroutine(PlayKicks());
    }

    private IEnumerator PlayAttacks()
    {
        isAttacking = true;
        animator.Play(attacks[c]);
        powerUp.Play();

        c = (c + 1) % attacks.Length;
        findNearestTarget();

        yield return new WaitForSeconds(speed);
        isAttacking = false;
    }

    private IEnumerator PlayKicks()
    {
        isAttacking = true;
        animator.Play(kickAttacks[c]);
        c = (c + 1) % kickAttacks.Length;
        findNearestTarget();

        yield return new WaitForSeconds(speed);
        isAttacking = false;
    }

    public void findNearestTarget()
    {
        GameObject[] all = GameObject.FindGameObjectsWithTag("enemy");
        if (all.Length == 0) return;

        float minDist = float.MaxValue;
        GameObject nearest = null;

        foreach (GameObject enemy in all)
        {
            float currDist = Vector3.Distance(transform.position, enemy.transform.position);
            if (currDist < minDist)
            {
                nearest = enemy;
                minDist = currDist;
            }
        }

        if (nearest != null)
        {
            target = nearest;
            //StartCoroutine(moveTowards());
        }
    }

    IEnumerator moveTowards()
    {
        if (target == null) yield break;

        float speed = 20f;

        while (target != null && Vector3.Distance(transform.position, target.transform.position) > 1f)
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                speed * Time.deltaTime
            );
            yield return null;
        }
    }
}
