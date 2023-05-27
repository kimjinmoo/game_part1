using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed ;
    [SerializeField] protected Transform player;

    private protected Rigidbody2D rb;
    private protected Vector2 movement;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();
    }

    void followTarget()
    {
        if(Vector2.Distance(transform.position, player.position) > 1f) {
            animator.SetFloat("RunState", 0.5f);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }    else {
            animator.SetFloat("Attack", 0.5f);
            rb.velocity = Vector2.zero;
        }
    }
 }
