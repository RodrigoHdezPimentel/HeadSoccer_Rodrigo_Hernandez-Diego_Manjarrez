using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.text == "0")
        {
            panel.SetActive(true);
        }
    }
}
