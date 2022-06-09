using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeStart = 60;
    public TextMeshPro textBox;

    private string GetTime() => Mathf.Round(timeStart).ToString(CultureInfo.CurrentCulture);

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = "Time: " + GetTime();;
        if (timeStart <= 0.0)
        {
            //TODO go to end scene and send score
        }
    }
}
