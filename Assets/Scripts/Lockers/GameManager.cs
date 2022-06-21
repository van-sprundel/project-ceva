using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    private const float MAX_DISTANCE = 17f;
    public TextManager manager;
    public TimerScript script;
    public float timescale = 1f;
    public Button button;

    public Dictionary<RackData, (bool, int)> dictionary;

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

    private (int x, int y) RackDataToCoordinate(RackData d)
    {
        return ((int)d.color, (int)d.letter);
        // ((d.number - 1) * (d.color + 1), d.letter)
    }

    private int GetBestRoute((int x, int y) point, List<(int x, int y)> otherPoints)
    {
        if (!otherPoints.Any())
            return 0;

        // Calculate closest point
        // var closestPoint = otherPoints.MinBy(p => Distance(p, point));
        var closestDistance = otherPoints.Min(p => Distance(p, point));
        var closestPoint = otherPoints.First(x => Distance(x, point) == closestDistance);

        otherPoints.Remove(closestPoint);
        return closestDistance + GetBestRoute(closestPoint, otherPoints);
    }

    private int Distance((int x, int y) c1, (int x, int y) c2)
    {
        return Math.Abs(c1.x - c2.x) + Math.Abs(c1.y - c2.y);
    }

    private float CalculateCoefficient()
    {
        var points = dictionary.Keys.Select(RackDataToCoordinate).ToList();
        float distance = GetBestRoute(points.First(), points.Skip(1).ToList());
        Debug.Log($"Most efficient distance is: {distance}");
        return distance / MAX_DISTANCE;
    }

    public void SaveScore(float time)
    {
        var score = time * CalculateCoefficient();
        Debug.Log("Saving score: " + score);
        if (PlayerPrefs.GetFloat("pickOrderScore") < score)
        {
            PlayerPrefs.SetFloat("pickOrderScore", (float)Math.Round(score));
            PlayerPrefs.Save();
        }
    }

    public void Finish()
    {
        var time = script.StopRunning();
        TotalScore.OrderPlayed();
        SaveScore(time);
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
                Time.timeScale = 0f;
                button.gameObject.SetActive(true);
                Finish();
            }
        }
    }

    private IEnumerable<RackData> getRandomOrders()
    {
        var rnd = new Random();

        while (true)
        {
            var color = rnd.Next(0, 3);
            var number = rnd.Next(0, 3);
            var letter = rnd.Next(0, 6);
            yield return new RackData { number = number + 1, color = (Color)color, letter = (Letter)letter };
        }
    }
}