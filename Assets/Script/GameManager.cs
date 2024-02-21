using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] points;
    public TextMeshProUGUI pointsScore;
    public static GameManager Instance;
    public GameObject panel;

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
     
        points = new int[2];
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
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

    public void SumarPunto(int player)
    {
        //Sumar puntos
        points[player]++;
        pointsScore.text = points[1] + " - " + points[0];
    }
}
