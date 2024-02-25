using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float targetTime = 60.0f;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI winner;

    void Start()
    {
        //Resetea a valores deseados
        timer.text = targetTime.ToString();
        timer.color = Color.white;
        StartCoroutine(DecreaseTime());

    }
    private void Update()
    {
        //Comprueba el tiempo restante
        if (targetTime == 0)
        {
            winner.text = GameManager.Instance.getWinner();
        }
        //Si quedan menos de 15 sec, el contador se vuelve rojo
        if(int.Parse(timer.text) <= 15)
        {
            timer.color = Color.red;
        }
        GameManager.Instance.setTime(targetTime);
    }
    IEnumerator DecreaseTime()
    {
        //Contador
        while (targetTime > 0)
        {
            targetTime -= 1;
            yield return new WaitForSeconds(1);
            timer.text = targetTime.ToString();
        }
    }
}
