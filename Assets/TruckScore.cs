using TMPro;
using UnityEngine;

public class TruckScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    private float loadTruckScore;

    // Start is called before the first frame update
    private void Start()
    {
        loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");
        text.text = "Score: " + (loadTruckScore);
    }
}