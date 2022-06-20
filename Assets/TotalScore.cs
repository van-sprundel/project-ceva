using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    private float loadTruckScore;
    private float pickOrderScore;

    private void Awake()
    {
        if (!started)
        {
            started = true;
            PlayerPrefs.SetFloat("pickOrderScore", 0);
            PlayerPrefs.SetFloat("loadTruckScore", 0);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");
        pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        text.text = "Your Score: " + (loadTruckScore + pickOrderScore);
    }
}