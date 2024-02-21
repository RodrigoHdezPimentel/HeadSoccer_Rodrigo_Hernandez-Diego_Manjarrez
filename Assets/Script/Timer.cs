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
         timer.text = targetTime.ToString();
        timer.color = Color.white;
        StartCoroutine(DecreaseTime());

    }
    private void Update()
    {
        if (targetTime == 0)
        {
            winner.text = GameManager.Instance.getWinner();
        }
        if(int.Parse(timer.text) <= 15)
        {
            timer.color = Color.red;
        }
    }
    IEnumerator DecreaseTime()
    {
        while (targetTime > 0)
        {
            targetTime -= 1;
            yield return new WaitForSeconds(1);
            timer.text = targetTime.ToString();
        }
    }

}
