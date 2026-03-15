using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinalScene : MonoBehaviour
{
    public GameObject clickPromptText;

    public void OnScreenClicked()
    {
        if (clickPromptText != null) 
        {
            clickPromptText.SetActive(false);
        }
        
        DetermineEnding();
    }

    public void DetermineEnding()
    {
        if (GameManager.nutritionScore >= 10) 
        {
            SceneManager.LoadScene("BestEndingHomeScreen");
        }
        else if (GameManager.nutritionScore >= 5) 
        {
            SceneManager.LoadScene("MidEndingHomeScreen");
        }
        else 
        {
            SceneManager.LoadScene("FailedEndingHomeScreen");
        }
    }
}