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
            _dir = new Vector2(1, 0);
            _spriteRenderer.flipX = (rotation == false);

        }
        else if (Input.GetKey(left))
        {
            _dir = new Vector2(-1, 0);
            _spriteRenderer.flipX = (rotation == true);

        }
        else if (Input.GetKeyDown(jump) && isGrounded)
        {
            Debug.Log("Jumping!");
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = _dir * speed;
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
