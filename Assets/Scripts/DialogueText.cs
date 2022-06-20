using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public Button button;
    private string text;

    private bool textDone;
    private TextMeshPro textMeshPro;

    // Start is called before the first frame update
    private void Start()
    {
        button.gameObject.SetActive(false);
        textMeshPro = GetComponent<TextMeshPro>();
        text = textMeshPro.text;
        textMeshPro.text = "";
        StartCoroutine(UpdateText());
    }

    private void Update()
    {
        if (textDone)
        {
            textDone = false;
            button.gameObject.SetActive(true);
        }
    }

    private IEnumerator UpdateText()
    {
        for (var i = 0; i < text.Length + 1; i++)
        {
            textMeshPro.text = text.Substring(0, i);
            yield return new WaitForSeconds(0.04f);
        }

        textDone = true;
    }
}