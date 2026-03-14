using UnityEngine;
using TMPro;

public class UniversalFader : MonoBehaviour
{
    public enum FadeMode { FadeIn, FadeOut }
    public FadeMode mode;
    
    public float fadeTime = 2.0f;
    public GameObject nextObject;
    
    private TextMeshProUGUI textElement;
    private float alphaValue;
    private float fadeSpeed;
    private bool hasFinished = false;

    void Start()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        fadeSpeed = 1.0f / fadeTime;
        if (mode == FadeMode.FadeIn) {
            alphaValue = 0;
        } else {
            alphaValue = 1;
        }
        SetAlpha(alphaValue);
        if (nextObject != null) nextObject.SetActive(false);
    }

    void Update()
    {
        if (hasFinished) return;

        if (mode == FadeMode.FadeIn)
        {
            alphaValue += fadeSpeed * Time.deltaTime;
            if (alphaValue >= 1) { alphaValue = 1; Finish(); }
        }
        else
        {
            alphaValue -= fadeSpeed * Time.deltaTime;
            if (alphaValue <= 0) { alphaValue = 0; Finish(); }
        }

        SetAlpha(alphaValue);
    }

    void SetAlpha(float a)
    {
        Color c = textElement.color;
        textElement.color = new Color(c.r, c.g, c.b, a);
    }

    void Finish()
    {
        hasFinished = true;
        
        if (nextObject != null)
        {
            nextObject.SetActive(true);
        }
    }
}