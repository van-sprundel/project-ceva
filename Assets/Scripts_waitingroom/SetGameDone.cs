using UnityEngine;

public class SetGameDone : MonoBehaviour
{
    public static bool loadTruckDone = false;
    public static bool circlePickOrderDone = false;
    public GameObject circleLoadTruck;
    public GameObject circlePickOrder;

    public LoadScene loadSceneTruck;
    public LoadScene loadSceneOrderPick;

    // Update is called once per frame
    private void Update()
    {
        if (loadTruckDone) SetDoneTruck();
        if (circlePickOrderDone) SetDoneOrder();
    }

    public void SetDoneTruck()
    {
        loadSceneTruck.DisableDoor();
        circleLoadTruck.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }

    public void SetDoneOrder()
    {
        loadSceneOrderPick.DisableDoor();
        circlePickOrder.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
        ;
    }
}