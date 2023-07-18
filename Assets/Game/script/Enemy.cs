using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed ;
    [SerializeField] protected Transform player;

    // �������� Ÿ�� ����
    private protected Rigidbody2D rb;
    private protected Vector2 movement;

    // ����
    bool isLive;

    private Animator animator;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); ;
        animator = GetComponent<Animator>();
    }

  
    void FixedUpdate()
    {
        followTarget();
    }

    void LateUpdate()
    {
        //  ������ ���Ѵ�.
        Vector3 dir = player.position - transform.position;

        if (dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    private void OnEnable()
    {
        player = GameManager.instance.player.GetComponent<Transform>();
    }

    void followTarget()
    {
       // �ɸ��͸� �i�´�.
        if (Vector2.Distance(transform.position, player.position) > 1f) {    
            animator.SetFloat("RunState", 0.5f);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }    else {
            animator.SetTrigger("Attack");
            rb.velocity = Vector2.zero;
        }
    }
 }
