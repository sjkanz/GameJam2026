using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1; 

    }
    public void LoadSpecificScene(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("ERROR: The scene '" + sceneName + "' cannot be loaded. " +
                "Check that the name is spelled exactly right and it's in File > Build Settings!");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Application...");
        Application.Quit();
    }
}