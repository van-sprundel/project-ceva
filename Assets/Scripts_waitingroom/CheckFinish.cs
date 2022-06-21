using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFinish : MonoBehaviour
{
    public Button Button;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SetGameDone.LoadTruckDone && SetGameDone.PickOrderDone)
        {
            Button.gameObject.SetActive(true);
        }
        else
        {
            Button.gameObject.SetActive(false);
        }
    }
}
