using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayTetris()
    {
        SceneManager.LoadScene("Scenes/Tetris");
    }

    public void PlayLockers()
    {
        SceneManager.LoadScene("Scenes/Lockers");
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/2D waiting");
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void WaitingRoom()
    {
        SceneManager.LoadScene("Scenes/2D waiting");
    }
}