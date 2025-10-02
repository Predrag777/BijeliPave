using UnityEngine;
using System.Collections;
public class BanditAttack : MonoBehaviour
{
    Bandit bandit;
    GameObject target;
    Animator anim;

    Rigidbody rb;
    bool logAttack=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            PerformAttack(target);
        }
    }

    void MoveAttack(GameObject target)
    {
        float step = 3f * Time.deltaTime; 
        Vector3 targetPos = target.transform.position;

        Vector3 direction = (targetPos - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);

        float dist = Vector3.Distance(transform.position, targetPos);
        if (dist > 1.5f) 
        {
            rb.MovePosition(transform.position + direction * step);
            anim.SetBool("isFight", true);
        }
        else
        {
            anim.SetBool("isFight", false);
        }
    }


    void PerformAttack(GameObject target)
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 2f)
        {
            if(!logAttack)
                StartCoroutine(PerformPunch());
        }
    }
    IEnumerator PerformPunch()
    {
        logAttack = true;
        anim.Play("punch");
        yield return new WaitForSeconds(1f);
        logAttack = false;
    }
    
}
