using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] points;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            //GameManager instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }
   
    public string getWinner()
    {
        if (points[0] < points[1])
        {
            return "Ganador\nNaranja";
        }else if (points[0] > points[1])
        {
            return "Ganador\nVerde";
        }
        else
        {
            return "Empate";
        }
    }
    public void setPoints(int[] points)
    {
        this.points = points;

    }
    public int[] getPoints()
    {
        return points;
    }

}
