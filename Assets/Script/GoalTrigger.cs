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
        int[] puntos = { 0, 0 };
        confeti.SetActive(false);
        pointsScore.text = "0 - 0";
        GameManager.Instance.setPoints(puntos);
    }

    // Update is called once per frame
    void Update()
    {
        points = new int[2];
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        //Deteccion de goal
        if (collision.gameObject.GetComponent<BallMovement>())
        {
            StartCoroutine(Confeti());
            Debug.Log("goooooooaaaaaaaaal");
            collision.gameObject.SetActive(false);
            BallSpawner.objetsAlive.Remove(collision.gameObject);
            SumarPunto(numPorteria);
        }
    }
    IEnumerator Confeti()
    {
        confeti.SetActive(true);        
        yield return new WaitForSeconds(3);
        confeti.SetActive(false);
    }
    public void SumarPunto(int player)
    {
        points = GameManager.Instance.getPoints();
        //Sumar puntos
        points[player]++;
        pointsScore.text = points[1] + " - " + points[0];
    }
}
