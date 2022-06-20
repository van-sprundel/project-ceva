using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public bool isFilledIn;
    public TextMeshProUGUI inputField;
    public Button button;

// Update is called once per frame
    private void Update()
    {
        // Make sure button is not clickable if input field is empty
        if (inputField.text == "")
            isFilledIn = false;
        else
            isFilledIn = true;

        if (Input.GetKeyDown(KeyCode.Return)) EnterDetails();
    }

    public void EnterDetails()
    {
        if (!isFilledIn) return;

        PlayerPrefs.SetString("Name", inputField.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("2D waiting");
    }
}