using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public float speed;
    private Rigidbody2D _rb;
    private Vector2 _dir;
    private SpriteRenderer _spriteRenderer;
    public bool rotation;
    public float jumpForce;
    private bool isGrounded;
    private Animator _animator;
    public List<Button> listaDeBotones;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Comprueba si el compilador es windows
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        _dir = Vector2.zero;
        //Movimiento a la derecha
        if (Input.GetKey(right))
        {
            //_dir = new Vector2(1, 0);
            _dir.x = 1;
            _spriteRenderer.flipX = (!rotation);
            _animator.SetBool("isWalking", true);

        }
        //Movimiento a la izq
        else if (Input.GetKey(left))
        {
            //_dir = new Vector2(-1, 0);
            _dir.x = -1;
            _spriteRenderer.flipX = (rotation);
            _animator.SetBool("isWalking", true);

        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
        //Se conprueba que el personaje toca el suelo para saltar
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            _animator.SetBool("isJumping", true);
        }
        //Comprueba que el compilador es android
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            //Detecta el primer click y evalua su posicion
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //Si es en el primer cuarto de la pantalla, el personaje se desplaza a la izq
                    if(touch.position.x < Screen.width / 4)
                    {
                        _dir.x = -1;
                        _spriteRenderer.flipX = (rotation);
                        _animator.SetBool("isWalking", true);
                    }
                    //Y si es en el segundo cuarto, a la derecha
                    else if(touch.position.x < Screen.width / 2 && touch.position.x > Screen.width / 4)
                    {
                        _dir.x = 1;
                        _spriteRenderer.flipX = (!rotation);
                        _animator.SetBool("isWalking", true);
                    }
                    //Si se toca la mitad derecha de la pantalla, salta
                    if(touch.position.x > Screen.width / 2 && isGrounded)
                    {
                        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        isGrounded = false;
                        _animator.SetBool("isJumping", true);
                    }

                    break;
                //Si se deja de tocar la pantalla, el personaje para
                case TouchPhase.Ended:
                    _dir.x = 0;
                    _spriteRenderer.flipX = (rotation);
                    _animator.SetBool("isWalking", false);
                    break;
            }
        }
#endif
    }
    private void FixedUpdate()
    {
        //Guarda una velocidad concreta para realizar el salto
        Vector2 newVel = _dir * speed;
        newVel.y = _rb.velocity.y;
        _rb.velocity = newVel;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded when colliding with a ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("isJumping", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Update the grounded flag when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            _animator.SetBool("isJumping", false);
        }
    }
}
