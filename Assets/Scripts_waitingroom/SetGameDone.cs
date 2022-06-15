using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameDone : MonoBehaviour
{
    public GameObject circleLoadTruck;
    public GameObject circlePickOrder;
    
    public LoadScene loadSceneTruck;
    public LoadScene loadSceneOrderPick;

    public static bool loadTruckDone = false;
    public static bool circlePickOrderDone = false;

    public void SetDoneTruck()
    {
        loadSceneTruck.DisableDoor();
        circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }
    
    public void SetDoneOrder()
    {
        loadSceneOrderPick.DisableDoor();
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
