using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    private float loadTruckScore;
    private float pickOrderScore;
    public TMP_Text text;
    public static bool started = false;

    void Awake()
    {
        if (!started)
        {
            started = true;
            PlayerPrefs.SetFloat("pickOrderScore", 0);
            PlayerPrefs.SetFloat("loadTruckScore", 0);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");
        pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        text.text = "Your Score: " + (loadTruckScore + pickOrderScore);
    }
    
    
}
