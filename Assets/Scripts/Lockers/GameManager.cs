using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Dictionary<RackData, (bool, int)> dictionary;
    public TextManager manager;
    public TimerScript script;
    public float timescale = 1f;
    public Button button;

    public void Start()
    {
        button.gameObject.SetActive(false);
        Time.timeScale = timescale;

        dictionary = new Dictionary<RackData, (bool, int)>();
        foreach (var order in getRandomOrders().Distinct().Take(9).Select((order, i) => (order, i))) 
        {
            dictionary.Add(order.order, (true, order.i));
            manager.UpdateLabel(order.i, order.order, true);
        }
    }

    public void Finish()
    {
        this.script.StopRunning();
    }
    
    public void handleHeadBang(RackData rackData)
    {
        Debug.Log($"{rackData.number}, {rackData.letter}, {rackData.color}: Collided");
        if (dictionary.ContainsKey(rackData))
        {
            var v = dictionary[rackData];
            dictionary[rackData] = (false, v.Item2);
            manager.UpdateLabel(v.Item2, rackData, false);
            if (dictionary.Values.All(x => x.Item1 == false))
            {
                Debug.Log("You won!");
                Time.timeScale = 0;
                button.gameObject.SetActive(true);
                Finish();
            }
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
            yield return new RackData { number = number + 1, color = (Color)color, letter = (Letter)letter };
        }
    }
}
