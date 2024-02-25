using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        //Oculta el panel
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Si el tiempo se ha acabado, aparece el contador
        if(GameManager.Instance.getTime() == 0)
        {
            panel.SetActive(true);
        }
    }
}
