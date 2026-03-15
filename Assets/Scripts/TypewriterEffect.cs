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
        OnContinueButtonClicked(fullText);
    }

    public void OnContinueButtonClicked(string nextMessage)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(RevealCharacters(nextMessage));
    }

    IEnumerator RevealCharacters(string message)
    {
        textComponent.text = message; 
        textComponent.maxVisibleCharacters = 0;

        for (int i = 0; i <= message.Length; i++)
        {
            textComponent.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delay); 
        }
    }
}