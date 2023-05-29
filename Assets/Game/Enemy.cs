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
        //  방향을 정한다.
        Vector3 dir = player.position - transform.position;
        Debug.Log("dir : " + dir.x);
       if(dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

       // 케릭터를 쫒는다.
        if (Vector2.Distance(transform.position, player.position) > 1f) {    
            animator.SetFloat("RunState", 0.5f);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }    else {
            rb.velocity = Vector2.zero;
        }
    }
 }
