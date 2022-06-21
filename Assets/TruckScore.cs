using TMPro;
using UnityEngine;

public class TruckScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    public TMP_Text truckGamesPlayed;
    private float loadTruckScore;

    // Start is called before the first frame update
    private void Start()
    {
        loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");
        truckGamesPlayed.text = "Times played: " + TotalScore.loadTruckTimesPlayed;
        text.text = "Score: " + (loadTruckScore);
    }
}