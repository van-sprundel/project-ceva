using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    private float loadTruckScore;
    private float pickOrderScore;

    public static int loadTruckTimesPlayed = 0;
    public static int pickOrderTimesPlayed = 0;

    private void Awake()
    {
        if (!started)
        {
            started = true;
            PlayerPrefs.SetFloat("pickOrderScore", 0);
            PlayerPrefs.SetFloat("loadTruckScore", 0);
        }
    }
    
    public static void TruckPlayed()
    {
        loadTruckTimesPlayed++;
    }
    
    public static void OrderPlayed()
    {
        pickOrderTimesPlayed++;
    }

    // Start is called before the first frame update
    private void Start()
    {
        loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");
        pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        text.text = "Your Score: " + (loadTruckScore + pickOrderScore);
    }
}