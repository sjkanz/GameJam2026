using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class TextEngine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string[] sentences;
    private int index = 0;
    public Text text;
    public GameObject dialogue;
    public Button nextButton;
    private int currentSceneIndex;
    private Coroutine typingCoroutine;
    public float delay = 0.001f;
    private bool isTyping = false;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sentences.Length > 0)
        {
            typingCoroutine = StartCoroutine(RevealCharacters(sentences[index]));
        }
    }
    public void NextSentence()
    {
        print("Next Sentence");

        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            text.text = sentences[index];
            isTyping = false;
            return;
        }

        if (index < sentences.Length - 1)
        {
            index++;
            typingCoroutine = StartCoroutine(RevealCharacters(sentences[index]));
        }
        else
        {
            index = 0;
            dialogue.SetActive(false);
        }
    }

    public void printStatus()
    {
        print("Click");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);
        }
        //text.text = sentences[index];
    }

    IEnumerator RevealCharacters(string message)
    {
        isTyping = true;
        text.text = ""; // Clear the text first
        for (int i = 0; i <= message.Length; i++)
        {
            text.text = message.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        isTyping = false;
    }



}
