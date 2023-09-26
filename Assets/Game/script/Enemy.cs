using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed ;
    [SerializeField] protected Transform player;

    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;

    // 중력
    private protected Rigidbody2D rb;
    private protected Collider2D coll;
    private protected Vector2 movement;

    // 살아있는지 여
    private bool isLive;

    private Animator animator;

    WaitForFixedUpdate wait;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        coll = this.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
    }

  
    void FixedUpdate()
    {
        followTarget();
    }

    void LateUpdate()
    {
        if (!isLive) return;

        print("position updated!!");
        //  Play 위치 계산
        Vector3 dir = (player.position - transform.position).normalized;

        // 거리가 1이하에서는 뒤에서 공격
        if (dir.x > 0)
        {
            //transform.localScale = new Vector2(-1, 1);
            //transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            //transform.localScale = new Vector2(1, 1);
            //transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    private void OnEnable()
    {
        player = GameManager.instance.player.GetComponent<Transform>();
        isLive = true;
        health = maxHealth;

    }

    public void Init(SpawnData data) {
        animator.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    void followTarget()
    {
        if (!isLive && health < 1) return;
        print("followTarget :  Die : " + isLive + "/" + health);
        // 접근 할 경우 공격
        if (Vector2.Distance(transform.position, player.position) > 1f) {
            animator.SetFloat("RunState", 0.5f);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }    else {
            animator.SetTrigger("Attack");
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Sword")) {
            return;
        } else {
            print("health : " + health);
            health -= collision.GetComponent<Sword>().damage;
            //StartCoroutine(KnocBack());

            if( health > 0 ) {
                // live
                animator.SetTrigger("Hit");
            }
            else {
                // dead
                isLive = false;
                coll.enabled = false;
                rb.simulated = false;

                Dead();
            }
        }
    }

    IEnumerator KnocBack() {
        yield return wait;
        Vector3 playPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playPos;

        //transform.position = Vector2.MoveTowards(transform.position, dirVec * 3, moveSpeed * Time.deltaTime);
        //rb.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

    }

    void Dead() {
        animator.SetTrigger("Die");
        //gameObject.SetActive(false);

    }
}
