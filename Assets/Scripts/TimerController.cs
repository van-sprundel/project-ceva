using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshPro textBox;
    private bool _done;
    private float timer = 60;

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

    private string GetTime()
    {
        return Mathf.Round(timer).ToString(CultureInfo.CurrentCulture);
    }

    public void SaveScore()
    {
        var score = EvaluateScore();
        PlayerPrefs.SetFloat("loadTruckScore", score);
        PlayerPrefs.Save();
        SetGameDone.LoadTruckDone = true;
        SceneManager.LoadScene("TetrisEnd");
    }

    private int EvaluateScore()
    {
        var squares = SnapController._grid;
        var squaresFilled = 0;
        foreach (var square in squares)
            if (square)
                squaresFilled += 1;

        return squaresFilled + (int)timer;
    }
}