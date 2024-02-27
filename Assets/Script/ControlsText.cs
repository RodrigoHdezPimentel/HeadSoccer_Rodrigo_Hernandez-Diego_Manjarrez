using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlsText : MonoBehaviour
{
    private TextMeshProUGUI controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = gameObject.GetComponent<TextMeshProUGUI>();
       controls.SetText("Move with keys 'a','w','d' in computer\n1st 1/4 screen left, 2nd 1/4 screen right,\n2nd 1/2 screen jump for movile");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
