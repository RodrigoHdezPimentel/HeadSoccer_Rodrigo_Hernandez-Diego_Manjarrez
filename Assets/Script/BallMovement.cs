using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float velocidad; // Ajusta la velocidad seg�n tus necesidades

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcular la direcci�n opuesta al golpe
            Vector2 direccionOpuesta = (transform.position - collision.transform.position).normalized;

            // Mantener la direcci�n vertical, cambiar solo la horizontal
            direccionOpuesta.y = 0.45f;

            // Aplicar la fuerza en la direcci�n opuesta
            _rb.AddForce(direccionOpuesta * velocidad, ForceMode2D.Impulse);
        }
    }
}
