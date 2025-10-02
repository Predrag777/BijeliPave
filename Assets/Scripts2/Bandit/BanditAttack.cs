using UnityEngine;
using System.Collections;
public class BanditAttack : MonoBehaviour
{
    Bandit bandit;
    GameObject target;
    Animator anim;


    bool logAttack=false;
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
            PerformAttack(target);
        }
    }

    void MoveAttack(GameObject target)
    {
        float step = 10f * Time.deltaTime;
        anim.SetBool("isFight", true);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
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
