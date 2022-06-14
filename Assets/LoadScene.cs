using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScene : MonoBehaviour
{
    // public Scene 
    public string sceneName;
    private bool isEntered = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && !isEntered)
        {
            isEntered = true;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadMainScreen()
    {
        Debug.Log("Button cl");
        SceneManager.LoadScene("2D waiting");
    }
}
