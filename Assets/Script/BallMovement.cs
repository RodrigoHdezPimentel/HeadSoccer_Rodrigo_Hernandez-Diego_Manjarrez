using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float velocidad;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direccionOpuesta = (transform.position - collision.transform.position).normalized;
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mantener la direcci�n vertical, cambiar solo la horizontal
            direccionOpuesta.y = 0.45f;

            // Aplicar la fuerza en la direcci�n opuesta
            _rb.AddForce(direccionOpuesta * velocidad, ForceMode2D.Impulse);

        }else if (collision.gameObject.CompareTag("border"))
        {
            direccionOpuesta.y = -0.45f;
            _rb.AddForce(direccionOpuesta * velocidad/2, ForceMode2D.Impulse);
        }

    }
}
