using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public enum Color
{
    Red,
    Blue,
    Green
}

public enum Letter
{
    A,
    B,
    C,
    D,
    E,
    F
}

public class Rack : MonoBehaviour
{
    public int number;
    public Letter letter;
    public Color color;
    public Material green;
    public Material blue;
    public Material red;
    private List<Box> boxes;
    private TextMeshPro numberText;


    private void Start()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
        numberText.text = number.ToString();
        boxes = GetComponentsInChildren<Box>().ToList();
        var material = color switch
        {
            Color.Red => red,
            Color.Blue => blue,
            Color.Green => green,
            _ => red
        };
        foreach (var box in boxes) box.GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}