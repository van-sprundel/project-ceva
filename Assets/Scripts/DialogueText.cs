using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private string text;

    private bool textDone;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        text = textMeshPro.text;
        textMeshPro.text = "";
             StartCoroutine( UpdateText());
        
    }

    private void Update()
    {
        if (textDone)
        {
            textDone = false;
            //TODO show button
        }
    }

    IEnumerator UpdateText()
    {
        for (int i = 0; i < text.Length+1; i++)
        {
            textMeshPro.text = text.Substring(0, i);
            yield return new WaitForSeconds(0.04f);
        }

        textDone = true;
    }
}
