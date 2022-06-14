using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class TimerScript : MonoBehaviour
{
    private TextMeshProUGUI _TextMeshPro;
    public UnityEvent timeElapsed;
    private bool running;

    private float _startTime = 150f;
    // Start is called before the first frame update
    void Start()
    {
        running = true;
        _TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void StopRunning()
    {
        running = false;
        _TextMeshPro.text = "You won! Score: " + GetTime();
        SetGameDone.loadTruckDone = true;
    }

    private string GetTime() => Math.Round(_startTime).ToString(CultureInfo.CurrentCulture);

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            _startTime -= Time.deltaTime;
            _TextMeshPro.text = "Time: " + GetTime();
            
            if (_startTime <= 0.0)
            {
                // invoke event
                timeElapsed.Invoke();
                StopRunning();
            }
        }
        
    }
}
