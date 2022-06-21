using System.Collections;
using TMPro;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public AudioSource TextStab;
    public static bool DialogueFinished = true;
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
        SetGameDone.HasStarted = false;
        backgroundImage.SetActive(true);
        TextStab.volume = 0.1f;
        if (!DialogueFinished && PlayerPrefs.GetInt("FirstDialogue") == 0)
        {
            PlayerPrefs.SetInt("FirstDialogue",1);
            PlayerPrefs.Save();
            backgroundImage.SetActive(true);
            var playerName = PlayerPrefs.GetString("Name");
            _textRows[0] = _textRows[0].Substring(0, _textRows[0].Length - 1) + ", " + playerName + "!";
            StartCoroutine(UpdateText());
        }
        else
        {
            SetGameDone.HasStarted = true;
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
                TextStab.Play();
            }
            yield return new WaitForSeconds(2.0f);
        }
        DialogueFinished = true;
        SetGameDone.HasStarted = true;

        currentText.text = "";
        backgroundImage.SetActive(false);
    }
}