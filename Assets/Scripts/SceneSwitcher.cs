using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayTetris()
    {
        SceneManager.LoadScene(sceneName:"Scenes/Tetris");
    }
    
    public void PlayLockers()
    {
        SceneManager.LoadScene(sceneName:"Scenes/Lockers");
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
