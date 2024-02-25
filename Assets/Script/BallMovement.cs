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
        //Rebota la bola direccion opuesta al objeto con el que choca
        Vector2 direccionOpuesta = (transform.position - collision.transform.position).normalized;
        //Si choca con un jugador, llevará una trayectoria ascendente
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mantener la dirección vertical, cambiar solo la horizontal
            direccionOpuesta.y = 0.45f;

            // Aplicar la fuerza en la dirección opuesta
            _rb.AddForce(direccionOpuesta * velocidad, ForceMode2D.Impulse);
        //Si es con un borde de la panatalla, descendente
        }else if (collision.gameObject.CompareTag("border"))
        {
            direccionOpuesta.y = -0.45f;
            _rb.AddForce(direccionOpuesta * velocidad/2, ForceMode2D.Impulse);
        }

    }
}
