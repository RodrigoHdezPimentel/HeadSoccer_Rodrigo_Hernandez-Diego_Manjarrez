using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = Vector2.zero;
        if (Input.GetKey(right))
        {
            //_dir = new Vector2(1, 0);
            _dir.x = 1;
            _spriteRenderer.flipX = (!rotation);

        }
        else if (Input.GetKey(left))
        {
            //_dir = new Vector2(-1, 0);
            _dir.x = -1;
            _spriteRenderer.flipX = (rotation);

        }
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        
        }
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
