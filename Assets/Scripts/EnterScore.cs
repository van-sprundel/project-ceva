using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterScore : MonoBehaviour
{

    public TextMeshProUGUI TextMeshProUGUI;
    public TextMeshProUGUI TimesPlayed;
    // Start is called before the first frame update
    void Start()
    {
        var pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        var loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");

        var pickOrderPlayed = TotalScore.pickOrderTimesPlayed;
        var loadTruckPlayed = TotalScore.loadTruckTimesPlayed;

        TextMeshProUGUI.text = $"{pickOrderScore}\n\n{loadTruckScore}\n\n{pickOrderScore + loadTruckScore}";
        
        TimesPlayed.text = $"{pickOrderPlayed}\n\n{loadTruckPlayed}";

    }
    
}
