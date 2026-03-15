using UnityEngine;
using UnityEngine.SceneManagement; 

public class DialogueManager : MonoBehaviour
{
    public GameObject[] textBoxes; 
    public string sceneToLoadAtEnd; 
    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < textBoxes.Length; i++)
        {
            textBoxes[i].SetActive(i == 0);
        }
    }

    public void ShowNextBox()
    {
        Debug.Log("Button was clicked!");
        
        if (currentIndex < textBoxes.Length - 1)
        {
            textBoxes[currentIndex].SetActive(false);
            currentIndex++;
            textBoxes[currentIndex].SetActive(true);

            TypewriterEffect typewriter = textBoxes[currentIndex].GetComponent<TypewriterEffect>();
            if (typewriter != null)
            {
                typewriter.enabled = false;
                typewriter.enabled = true; 
            }
        }
        else
        {
            Debug.Log("Dialogue over. Jumping to scene: " + sceneToLoadAtEnd);
            SceneManager.LoadScene(sceneToLoadAtEnd);
        }
    }
}