using System;
using UnityEngine;

public class SetGameDone : MonoBehaviour
{
    public static bool HasStarted = true;
    public static bool LoadTruckDone = false;
    public static bool CirclePickOrderDone = false;
    public GameObject circleLoadTruck;
    public GameObject circlePickOrder;

    public LoadScene loadSceneTruck;
    public LoadScene loadSceneOrderPick;

    private void Start()
    {
        loadSceneTruck.DisableDoor();
        circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.grey;
        circlePickOrder.GetComponent<SpriteRenderer>().color = UnityEngine.Color.grey;
    }

    // Update is called once per frame
    private void Update()
    {
        if (HasStarted)
        {
            HasStarted = false;
            loadSceneTruck.EnableDoor();
            circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
            circlePickOrder.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
            
        }

        if (LoadTruckDone) SetDoneTruck();
        if (CirclePickOrderDone) SetDoneOrder();
    }

    private void SetDoneTruck()
    {
        loadSceneTruck.DisableDoor();
        circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }

    private void SetDoneOrder()
    {
        loadSceneOrderPick.DisableDoor();
        circlePickOrder.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }
}