using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    public Vector2 playInput;

    // 중력
    Rigidbody2D r;
   
    // 속도
    public float speed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        r = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        playInput.x = Input.GetAxisRaw("Horizontal");
        playInput.y = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(moveX, moveY, 0f);

        transform.Translate(moveVector.normalized * Time.deltaTime * speed);

        if (moveX > 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(1, 1, 1);

        if (moveX != 0 || moveY != 0)
        {
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetFloat("RunState", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }*/

    void OnMove(InputValue value)
    {
        playInput = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Die");
        }
        if (playInput.x != 0 || playInput.y != 0)
        {
            animator.SetFloat("RunState", 0.5f);

            if (playInput.x > 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (playInput.x < 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
        } else
        {
            animator.SetFloat("RunState", 0);
        }
        
    }

    void FixedUpdate()
    {
        // 힘을 준다.
        /*r.AddForce(playInput);*/

        // 속도 제어
        /*r.velocity = playInput;*/

        // 위치 이동
        Vector2 moveVector = playInput * speed * Time.fixedDeltaTime;
        r.MovePosition(r.position + moveVector);
    }

    public void attack()
    {
        animator.SetTrigger("Attack");
    }
}
