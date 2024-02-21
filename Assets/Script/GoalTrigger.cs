using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject confeti;
    public int numPorteria;
    // Start is called before the first frame update
    void Start()
    {
        confeti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        //Deteccion de goal
        if (collision.gameObject.GetComponent<BallMovement>())
        {
            StartCoroutine(Confeti());
            Debug.Log("goooooooaaaaaaaaal");
            collision.gameObject.SetActive(false);
            GameManager.Instance.SumarPunto(numPorteria);
        }
    }
    IEnumerator Confeti()
    {
        confeti.SetActive(true);        
        yield return new WaitForSeconds(5);
        confeti.SetActive(false);
    }
}
