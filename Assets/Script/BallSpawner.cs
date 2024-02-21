using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObjectPool pool;
    public TextMeshProUGUI timer;
    public static List<GameObject> objetsAlive;

    // Start is called before the first frame update
    void Start()
    {
        objetsAlive = new List<GameObject>();  
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = pool.GetInactiveGameObject();
        if (obj && (objetsAlive.Count == 0 || (int.Parse(timer.text) <= 15 && GameManager.Instance.getWinner() == "Empate")))
        {
            obj.SetActive(true);
            objetsAlive.Add(obj);
            obj.transform.position = transform.position; 
        }
        //if there're less than 15sec and it's a draw, create a ball
        if (int.Parse(timer.text) <= 15 && GameManager.Instance.getWinner() == "Empate")
        {
            GameObject obj2 = pool.GetInactiveGameObject();
            obj.SetActive(true);
            objetsAlive.Add(obj);
            obj.transform.position = transform.position;
        }
    }   
}
