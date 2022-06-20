using System.Collections;
using TMPro;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public static bool DialogueFinished;
    public TextMeshProUGUI currentText;
    public GameObject backgroundImage;

    private readonly string[] _textRows =
    {
        "Welcome!",
        "Use WASD or arrow keys to move. and SPACE to jump.",
        "There are two puzzle games, you can start with either one.",
        "At the end, your score will be calculated.",
        "Good luck!"
    };

    private int _selectedRow;

    // Start is called before the first frame update
    private void Start()
    {
        if (!DialogueFinished)
        {
            var playerName = PlayerPrefs.GetString("Name");
            _textRows[0] = _textRows[0].Substring(0, _textRows[0].Length - 1) + ", " + playerName + "!";
            backgroundImage.SetActive(true);
            StartCoroutine(UpdateText());
        }
        else
        {
            backgroundImage.SetActive(false);
        }
    }


    private IEnumerator UpdateText()
    {
        foreach (var row in _textRows)
        {
            for (var i = 0; i <= row.Length; i++)
            {
                currentText.text = row.Substring(0, i);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2.0f);
        }
        DialogueFinished = true;

        currentText.text = "";
        backgroundImage.SetActive(false);
    }
}