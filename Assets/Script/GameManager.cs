using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] points;
    public static GameManager Instance;
    private float time;

    private void Awake()
    {
        //Crea una unica instancia del GameManager (porque es singleton)
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
    //Devuelve el ganador en funcion de los puntos
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
    //Actualiza el contador
    public void setPoints(int[] points)
    {
        this.points = points;

    }
    //Devuleve el contadot
    public int[] getPoints()
    {
        return points;
    }
    //Actualiza el tiempo que queda
    public void setTime(float time)
    {
        this.time = time;
    }
    //Devuelve el tiempo que queda
    public float getTime()
    {
        return time;
    }

}
