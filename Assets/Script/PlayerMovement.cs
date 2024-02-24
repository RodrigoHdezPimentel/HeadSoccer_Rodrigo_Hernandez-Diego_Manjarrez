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
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        _dir = Vector2.zero;
        if (Input.GetKey(right))
        {
            //_dir = new Vector2(1, 0);
            _dir.x = 1;
            _spriteRenderer.flipX = (!rotation);
            _animator.SetBool("isWalking", true);

        }
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
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            _animator.SetBool("isJumping", true);
        }
#endif
    }
    private void FixedUpdate()
    {
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
