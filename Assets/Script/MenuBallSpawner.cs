using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBallSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObjectPool pool;
    private Rigidbody2D _rb;
    private Camera _camera;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _spriteRenderer = objectToSpawn.GetComponent <SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Genera aleatoriamente en el tiempo pelotas para hacer el menu mas dinamico
        if(Random.Range(0,100)  == 0)
        {

            GameObject ball = pool.GetInactiveGameObject();
            SpawnBall(ball);
        }
    }
    private void OnBecameInvisible()
    {
        
    }
    public void SpawnBall(GameObject ball)
    {
        //Si ha creado una bola con exito, la lanza con un angulo y fuerza aleatoria
        if (ball)
        {
            ball.SetActive(true);
            _rb = ball.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 2;

            float randomX = Random.Range(0.5f, 1.0f);
            float randomY = Random.Range(0.5f, 1.0f);

            // Aplica una fuerza con dirección aleatoria hacia arriba a la derecha
            _rb.AddForce(new Vector2(randomX, randomY) * Random.Range(15, 25), ForceMode2D.Impulse);

            StartCoroutine(desactivateBall(ball));


        }
    }
    //Despues de 2sec (que la bola ya ha salido de pantalla), la desactiva para poder crear otra
    IEnumerator desactivateBall(GameObject ball)
    {
        yield return new WaitForSeconds(2);
        ball.transform.position = GetComponentInParent<MenuBallSpawner>().transform.position;
        ball.SetActive(false);
    }

}
