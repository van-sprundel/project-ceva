using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeStart = 30;
    public TextMeshPro textBox;
    private bool done;

    private string GetTime() => Mathf.Round(timeStart).ToString(CultureInfo.CurrentCulture);

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = "Time: " + GetTime();
        if (timeStart <= 0.0 &&!done)
        {
            done =true;
            //TODO go to end scene and send score
            var squares = SnapController._grid;
            var squaresFilled = 0;
            foreach (var square in squares)
            {
                if (square)
                {
                    squaresFilled += 1;
                }
            }
            Debug.Log($"Squares filled: {squaresFilled}");
        }
    }
}
