using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        var score = PlayerPrefs.GetFloat("TetrisHighScore");
        _textMeshPro.text = score.ToString(CultureInfo.CurrentCulture);
    }
}