using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<RackData, (bool, int)> dictionary;
    public TextManager manager;

    public void Start()
    {
        dictionary = new Dictionary<RackData, (bool, int)>();
        foreach (var order in getRandomOrders().Distinct().Take(9).Select((order, i) => (order, i))) 
        {
            dictionary.Add(order.order, (true, order.i));
            manager.UpdateLabel(order.i, order.order, true);
        }
    }
    public void handleHeadBang(RackData rackData)
    {
        Debug.Log($"{rackData.number}, {rackData.letter}, {rackData.color}: Collided");
        if (dictionary.ContainsKey(rackData))
        {
            var item = dictionary[rackData];
            dictionary[rackData] = (false, item.Item2);
            manager.UpdateLabel(item.Item2, rackData, false);

        }
    }

    private IEnumerable<RackData> getRandomOrders()
    {

        var rnd = new System.Random();

        while (true)
        {
            var color = rnd.Next(0, 3);
            var number = rnd.Next(0, 3);
            var letter = rnd.Next(0, 6);
            yield return new RackData { number = number, color = (Color)color, letter = (Letter)letter };
        }
    }
}
