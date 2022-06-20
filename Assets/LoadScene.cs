using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // public Scene 
    public string sceneName;
    public bool isActive = true;
    private bool _isEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (!collision.gameObject.CompareTag("Player") || _isEntered) return;
        if (!StartDialogue.DialogueFinished) return;
        _isEntered = true;
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