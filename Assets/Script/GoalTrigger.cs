using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject confeti;
    public int numPorteria;
    public TextMeshProUGUI pointsScore;
    private int[] points;
    // Start is called before the first frame update
    void Start()
    {
        //Reinicia el contador
        int[] puntos = { 0, 0 };
        confeti.SetActive(false);
        pointsScore.text = "0 - 0";
        GameManager.Instance.setPoints(puntos);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        //Deteccion de gol
        if (collision.gameObject.GetComponent<BallMovement>() && GameManager.Instance.getTime() > 0)
        {
            StartCoroutine(Confeti());
            Debug.Log("goooooooaaaaaaaaal");
            collision.gameObject.SetActive(false);
            //Se lleva la cuenta del numero de balones en una lista
            BallSpawner.objetsAlive.Remove(collision.gameObject);
            SumarPunto(numPorteria);

            AudioManager.instance.PlayAudio();
        }
    }
    //Se activa el confeti en caso de gol
    IEnumerator Confeti()
    {
        confeti.SetActive(true);        
        yield return new WaitForSeconds(3);
        confeti.SetActive(false);
    }
    //Sumamos puntos al marcador
    public void SumarPunto(int player)
    {
        points = GameManager.Instance.getPoints();
        //Sumar puntos
        points[player]++;
        pointsScore.text = points[1] + " - " + points[0];
    }
}
