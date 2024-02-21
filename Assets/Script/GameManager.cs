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

    public void SumarPunto(int player)
    {
        //Sumar puntos
        points[player]++;
        pointsScore.text = points[1] + " - " + points[0];
    }
}
