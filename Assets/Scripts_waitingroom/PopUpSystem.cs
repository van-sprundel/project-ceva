using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator popUp;
    public TMP_Text popUpText;

    public void PopUp(string text) {
        popUpBox.SetActive(true);
        popUpText.text = text;
        popUp.SetTrigger("pop");
    }

}
