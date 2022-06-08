using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TImeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart = 60;
    public Text textBox;

    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = "Time: " + Mathf.Round(timeStart).ToString();
    }
}
