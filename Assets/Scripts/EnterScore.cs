using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterScore : MonoBehaviour
{

    public TextMeshProUGUI TextMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        var pickOrderScore = PlayerPrefs.GetFloat("pickOrderScore");
        var loadTruckScore = PlayerPrefs.GetFloat("loadTruckScore");

        TextMeshProUGUI.text = $"{pickOrderScore}\n\n{loadTruckScore}\n\n{pickOrderScore + loadTruckScore}";

    }
    
}
