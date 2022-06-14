using System.Collections;
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
    private TextMeshPro numberText;
    private List<Box> boxes;

    public int number;
    public Letter letter;
    public Color color;
    public Material green;
    public Material blue;
    public Material red;
   

    void Start()
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
        foreach (var box in boxes) {
            box.GetComponent<MeshRenderer>().material = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
