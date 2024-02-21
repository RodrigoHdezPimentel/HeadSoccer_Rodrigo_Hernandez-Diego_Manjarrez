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
        panel.SetActive(false);
        points = new int[2];
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void SumarPunto(int player)
    {
        //Sumar puntos
        points[player]++;
        pointsScore.text = points[1] + " - " + points[0];
    }
}
