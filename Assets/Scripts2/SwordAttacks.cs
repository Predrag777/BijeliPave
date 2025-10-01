using UnityEngine;
using System.Collections;
public class SwordAttacks : MonoBehaviour
{
    private Knight knight;
    private Animator animator;

    private string[] basic = { "sword1", "sword2" };
    private string[] large = { "bigSword1" };

    private int c1 = 0;
    private int c2 = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        knight = GetComponent<Knight>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("[SWORD] "+knight.isSword);
        if (!knight.isSword) return;

        if (Input.GetMouseButtonDown(0))
        {
            
            StartCoroutine(SwordBasics());
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(BigSword());
        }
    }

    IEnumerator SwordBasics()
    {
        animator.Play(basic[c1]);
        c1++;
        if (c1 >= basic.Length)
            c1 = 0;
        
        yield return new WaitForSeconds(1f);
    }

    IEnumerator BigSword()
    {
        animator.Play(large[c2]);
        c2++;
        if (c2 >= large.Length)
            c2 = 0;

        yield return new WaitForSeconds(1f);
    }
}
