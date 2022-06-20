using System.Globalization;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        var score = PlayerPrefs.GetFloat("loadTruckScore");
        _textMeshPro.text = score.ToString(CultureInfo.CurrentCulture);
    }
}