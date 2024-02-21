using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] puntos;
    public TextMeshProUGUI[] pointsScore;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SumarPunto(int player)
    {
        //Sumar puntos
        puntos[player]++;
        pointsScore[player].text = "Puntos: " + puntos;
    }
}
