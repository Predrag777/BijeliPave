using UnityEngine;
using System.Collections;
public class Bandit : MonoBehaviour
{
    public float health = 5f;
    Animator animator;
    bool isHit = false;
    WeakPoint hitController;

    public bool isAttacking = false;

    AudioSource aSource;
    [SerializeField] AudioClip getPunched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitController = GetComponent<WeakPoint>();
        animator = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    
}
