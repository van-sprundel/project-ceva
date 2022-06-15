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
    public bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (!collision.gameObject.CompareTag("Player") || isEntered) return;
        isEntered = true;
        SceneManager.LoadScene(sceneName);
    }

    public void DisableDoor()
    {
        isActive = false;
    }

    public void LoadMainScreen()
    {
        Debug.Log("Button cl");
        SceneManager.LoadScene("2D waiting");
    }
}
