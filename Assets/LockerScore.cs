using TMPro;
using UnityEngine;

public class LockerScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    public TMP_Text numberGamesPlayed;
    private float pickOrderScore;

    // Start is called before the first frame update
    private void Start()
    {
        pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        numberGamesPlayed.text = "Times played: " + TotalScore.pickOrderTimesPlayed;
        text.text = "Score: " + (pickOrderScore);
    }
}