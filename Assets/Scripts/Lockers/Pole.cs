using TMPro;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public Letter letter;

    // Start is called before the first frame update
    private void Start()
    {
        var text = GetComponentInChildren<TextMeshPro>();
        text.text = letter.ToString();
    }
}