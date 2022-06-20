using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Canvas canvas;

    private List<Text> orders;

    // Start is called before the first frame update
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        orders = new List<Text>();
        foreach (var obj in GameObject.FindGameObjectsWithTag("Order"))
        {
            var text = obj.GetComponent<Text>();
            orders.Add(text);
        }
    }

    public void UpdateLabel(int index, RackData data, bool active)
    {
        var text = orders[index];
        text.text = data.ToString();
        var textColor = data.color switch
        {
            Color.Red => UnityEngine.Color.red,
            Color.Blue => UnityEngine.Color.blue,
            Color.Green => UnityEngine.Color.green,
            _ => UnityEngine.Color.red
        };
        text.color = active ? textColor : UnityEngine.Color.gray;
        text.fontStyle = active ? FontStyle.Bold : FontStyle.Italic;
    }
}