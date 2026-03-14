using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Drag your different Text GameObjects here
    public GameObject[] textBoxes; 
    private int currentIndex = 0;

    void Start()
    {
        // Ensure only the first box is active at the start
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
            // 1. Hide current box
            textBoxes[currentIndex].SetActive(false);

            // 2. Move to next
            currentIndex++;

            // 3. Show next box
            textBoxes[currentIndex].SetActive(true);

            // 4. Tell the Typewriter on the NEW box to run its Start logic
            // This works if your Typewriter script uses Start() or OnEnable()
            TypewriterEffect typewriter = textBoxes[currentIndex].GetComponent<TypewriterEffect>();
            if (typewriter != null)
            {
                typewriter.enabled = false;
                typewriter.enabled = true; 
            }
        }
        else
        {
            // Last box finished - disable the manager or panel
            textBoxes[currentIndex].SetActive(false);
            Debug.Log("End of sequence");
        }
    }
}