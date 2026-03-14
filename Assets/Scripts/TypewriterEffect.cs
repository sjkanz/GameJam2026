using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textComponent;
    public string fullText; 
    public float delay = 0.1f;

    private Coroutine typingCoroutine;

    void Start()
    {
        // Start the very first message
        OnContinueButtonClicked(fullText);
    }

    // Call this from the Button!
    public void OnContinueButtonClicked(string nextMessage)
    {
        // Stop any current typing so it doesn't glitch
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Run the typing effect for the new message
        typingCoroutine = StartCoroutine(RevealCharacters(nextMessage));
    }

    IEnumerator RevealCharacters(string message)
    {
        textComponent.text = message; // Set the new text
        textComponent.maxVisibleCharacters = 0;

        for (int i = 0; i <= message.Length; i++)
        {
            textComponent.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delay); 
        }
    }
}