using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiPlayer : MonoBehaviour
{
    public float speed;
    private float lastSpeed;

    private SpriteRenderer _spriteRenderer;
    public bool rotation;

    private bool isGrounded;
    private Animator _animator;
    private Transform target;
    private Rigidbody2D _rb;




    // Start is called before the first frame update
    void Start()
    {
        lastSpeed = speed;
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 1.5f;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.Instance.getTime() < 15)
        {
            lastSpeed = speed * 3f;
            _rb.gravityScale = 5f;
        }
        try
        {
            //Busca un objeto, en este caso es la pelota, para perseguirlo
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
                //Se actualiza su posicion para seguir a la pelota
                transform.position = Vector2.MoveTowards(transform.position, target.position, lastSpeed * Time.deltaTime);
            }
            else
            {
                //si la pelota esta en el aire, deja un margen de distancia
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x + 5, target.position.y), lastSpeed * Time.deltaTime);
            }
            //Giro el spriteRenderer en funcion a la direccion que vaya
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
