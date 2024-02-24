using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiPlayer : MonoBehaviour
{
    public float speed;
    private SpriteRenderer _spriteRenderer;
    public bool rotation;
    public float jumpForce;
    private bool isGrounded;
    private Animator _animator;
    private Transform target;



    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("goal").GetComponent<Transform>();
        }
        catch { }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            //Move the object Vector2.MoveTowards(from, to, speed);
            if (isGrounded)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x + 5, target.position.y), speed * Time.deltaTime);
            }
            if (transform.position.x < target.position.x)
            {
                _spriteRenderer.flipX = (!rotation);
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _spriteRenderer.flipX = (rotation);
                _animator.SetBool("isWalking", true);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded when colliding with a ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Update the grounded flag when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
