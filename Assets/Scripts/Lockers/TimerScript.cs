using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI _TextMeshPro;
    public UnityEvent<float> timeElapsed;

    private float _startTime = 150f;

    private bool running;

    // Start is called before the first frame update
    private void Start()
    {
        running = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (running)
        {
            _startTime -= Time.deltaTime;
            _TextMeshPro.text = "Time: " + GetTime();

            if (_startTime <= 0.0) StopRunning();
        }
    }

    public float StopRunning()
    {
        running = false;
        _TextMeshPro.text = "You won! Time: " + GetTime();
        SetGameDone.CirclePickOrderDone = true;
        return (float)Math.Round(_startTime);
    }

    private string GetTime()
    {
        return Math.Round(_startTime).ToString(CultureInfo.CurrentCulture);
    }
}