using UnityEngine;

public class BanditAttack : MonoBehaviour
{
    Bandit bandit;
    GameObject target;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        bandit = GetComponent<Bandit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("knight");
        }
        if (bandit.health > 0f && bandit.isAttacking)
        {

            MoveAttack(target);
        }
    }

    void MoveAttack(GameObject target)
    {
        float step = 5f * Time.deltaTime;
        anim.SetBool("isFight", true);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
