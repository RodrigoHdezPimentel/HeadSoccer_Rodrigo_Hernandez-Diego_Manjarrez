using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float targetTime = 60.0f;
    public TextMeshProUGUI timer;

    void Update()
    {
        while (targetTime >= 0)
        {
            StartCoroutine(DecreaseTime());
            timer.text = targetTime.ToString();
        }

    }
    IEnumerator DecreaseTime()
    {
        yield return new WaitForSeconds(1);
    }


}
