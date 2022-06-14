using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private TextMeshProUGUI _TextMeshPro;
    
    private float _startTime = 150f;
    // Start is called before the first frame update
    void Start()
    {
        _TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private string GetTime() => Math.Round(_startTime).ToString(CultureInfo.CurrentCulture);

    // Update is called once per frame
    void Update()
    {
        _startTime -= Time.deltaTime;
        _TextMeshPro.text = "Time: " + GetTime();
        
        if (_startTime <= 0.0)
        {
            // invoke event
        }
    }
}
