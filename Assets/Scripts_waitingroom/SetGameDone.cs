using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameDone : MonoBehaviour
{
    public GameObject circleLoadTruck;
    public GameObject circlePickOrder;

    public static bool loadTruckDone = false;
    public static bool circlePickOrderDone = false;
    public Material done;

    public void SetDoneTruck()
    {
        circleLoadTruck.GetComponent<MeshRenderer>().material = done;
    }
    
    public void SetDoneOrder()
    {
        circlePickOrder.GetComponent<MeshRenderer>().material = done;
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
