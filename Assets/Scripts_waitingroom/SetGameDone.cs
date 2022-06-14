using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameDone : MonoBehaviour
{
    public GameObject circleLoadTruck;
    public GameObject circlePickOrder;

    public static bool loadTruckDone = false;
    public static bool circlePickOrderDone = false;

    public void SetDoneTruck()
    {
        circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }
    
    public void SetDoneOrder()
    {
        circlePickOrder.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadTruckDone)
        {
            SetDoneTruck();
        }
        if (circlePickOrderDone)
        {
            SetDoneOrder();
        }
    }
}
