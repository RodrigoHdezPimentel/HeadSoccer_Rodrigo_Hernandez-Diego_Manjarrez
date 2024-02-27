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
    public static List<GameObject> objetsAlive;

    // Start is called before the first frame update
    void Start()
    {
        objetsAlive = new List<GameObject>();  
    }

    // Update is called once per frame
    void Update()
    {
        //only generate one ball unless there is less than 15sec and it is a draw
        GameObject obj = pool.GetInactiveGameObject();
        if (obj && (objetsAlive.Count == 0 || (GameManager.Instance.getTime() <= 15 && GameManager.Instance.getWinner() == "Empate")))
        {
            obj.SetActive(true);
            objetsAlive.Add(obj);
            obj.transform.position = transform.position; 
        }
        //if there're less than 15sec and it's a draw, create a ball
        if (GameManager.Instance.getTime() <= 15 && GameManager.Instance.getWinner() == "Empate" && objetsAlive.Count < 2)
        {
            GameObject obj2 = pool.GetInactiveGameObject();
            obj.SetActive(true);
            objetsAlive.Add(obj);
            obj.transform.position = transform.position;
        }
    }   
}
