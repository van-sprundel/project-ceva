using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Canvas canvas;
    private Dictionary<string, Text> orders;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        orders = new Dictionary<string, Text>();
        var colors = new Queue<(string, Color)>(getRandomOrders().Distinct().Take(9)); 
        foreach (var obj in GameObject.FindGameObjectsWithTag("Order"))
        {
            var text = obj.GetComponent<Text>();
            var (x, y) = colors.Dequeue();
            text.text = x;
            var textColor = y switch
            {
                Color.Red => UnityEngine.Color.red,
                Color.Blue => UnityEngine.Color.blue,
                Color.Green => UnityEngine.Color.green,
                _ => UnityEngine.Color.red,
            };
            text.color = textColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable<(string, Color)> getRandomOrders()
    {
        
        var rnd = new System.Random();
        
        while (true)
        {
            var color = rnd.Next(0, 3);
            var number = rnd.Next(0, 3);
            var letter = rnd.Next(0, 6);
            var code = $"{(Letter)letter}{number + 1}";
            yield return (code, (Color)color);
        }
    }
}
