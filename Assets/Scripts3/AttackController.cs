using UnityEngine;
using System.Collections;
public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject leftArm;
    [SerializeField] GameObject rightArm;
    [SerializeField] GameObject leftLeg;
    [SerializeField] GameObject rightLeg;


    private Animator animator;
    private Knight knight;
    private bool isAttacking = false;
    private string[] attacks = { "punch", "punch2" };
    private string[] kickAttacks = { "kick1", "kick2" };
    int c = 0;
    int c2 = 0;

    private float speed = 1f;

    private Collider leftArmCol, rightArmCol, leftLegCol, rightLegCol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        leftArmCol = leftArm.GetComponent<Collider>();
        rightArmCol = rightArm.GetComponent<Collider>();
        leftLegCol = leftLeg.GetComponent<Collider>();
        rightLegCol = rightLeg.GetComponent<Collider>();

        turnOffColliders();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (knight.health <= 0f) return;
        if (knight.isSword) return;*/
        if (isAttacking) {
            turnOnColliders();
            return;
        }
        else{
            turnOffColliders();
        }
    
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(PlayAttacks());
        if (Input.GetMouseButtonDown(1))
            StartCoroutine(PlayKicks());
    }

    
    private IEnumerator PlayAttacks()
    {
        isAttacking = true;
        animator.Play(attacks[c]);
        //powerUp.Play();

        c = (c + 1) % attacks.Length;

        yield return new WaitForSeconds(speed);
        isAttacking = false;
    }

    private IEnumerator PlayKicks()
    {
        isAttacking = true;
        animator.Play(kickAttacks[c]);
        c = (c + 1) % kickAttacks.Length;

        yield return new WaitForSeconds(speed);
        isAttacking = false;
    }

    private void turnOnColliders()
    {
        leftArmCol.enabled = rightArmCol.enabled = leftLegCol.enabled = rightLegCol.enabled = true;
    }

    private void turnOffColliders()
    {
        leftArmCol.enabled = rightArmCol.enabled = leftLegCol.enabled = rightLegCol.enabled = false;
    }



}
