using TMPro;
using UnityEngine;

public class LockerScore : MonoBehaviour
{
    public static bool started;
    public TMP_Text text;
    private float pickOrderScore;

    // Start is called before the first frame update
    private void Start()
    {
        pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        text.text = "Score: " + (pickOrderScore);
    }
}