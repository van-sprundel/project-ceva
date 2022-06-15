using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    private float timer = 60;
    public TextMeshPro textBox;
    private bool _done;

    private string GetTime() => Mathf.Round(timer).ToString(CultureInfo.CurrentCulture);

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        textBox.text = "Time: " + GetTime();
        if (timer <= 0.0 && !_done)
        {
            _done = true;
            SaveScore();
        }
    }

    public void SaveScore()
    {
        var score = EvaluateScore();
        PlayerPrefs.SetFloat("loadTruckScore", score);
        PlayerPrefs.Save();
        SetGameDone.loadTruckDone = true;
        SceneManager.LoadScene("TetrisEnd");
    }

    private int EvaluateScore()
    {
        var squares = SnapController._grid;
        var squaresFilled = 0;
        foreach (var square in squares)
        {
            if (square)
            {
                squaresFilled += 1;
            }
        }

        return squaresFilled + (int)timer;
    }
}