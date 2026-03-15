using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class BusGameManager3 : MonoBehaviour
{
    public GameObject eventPanel;
    public TMP_Text eventText;
    public TMP_Text buttonAText; 
    public TMP_Text buttonBText;
    
    public BusScroll[] backgrounds; 
    
    private float driveTimer = 0f;
    private bool stopTriggered = false; 

    void Start()
    {
        TriggerDecision("Last leg of the trip. Will you pay the $2 fare to reach the Supermarket?", "Pay $2", "Go Home");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            driveTimer += Time.deltaTime;
        }

        if (driveTimer > 7f && !stopTriggered) 
        {
            stopTriggered = true; 
        
            StopBusAndShow(
                "PHYSICAL LIMIT: The bags from the first two stops are digging into your shoulders. Your back is throbbing, and you still have to walk blocks to the Supermarket. You're exhausted.", 
                "Continue On", 
                "Go Home"
            );
        }
    }

    public void OnClickA()
    {
        // Initial fare payment
        if (driveTimer < 1f) {
            PlayerClass.payBusFare(); 
            Debug.Log("Paid fare. Money left: " + PlayerClass.currFunds);
            ClosePopup();
        }
        // Choosing to endure the pain to finish the errand
        else if (stopTriggered) {
            ClosePopup();
            StartCoroutine(WaitAndLoad("SupermarketCutscene", 3f));
        }
    }

    public void OnClickB() 
    {
        // If the bags are too heavy, they give up and trigger the Failed Ending
        StopAllCoroutines();
        Time.timeScale = 1;
        SceneManager.LoadScene("FinalHomeScreen"); 
    }

    void TriggerDecision(string message, string btnA, string btnB)
    {
        ToggleBus(false);
        ShowPopup(message, btnA, btnB);
    }

    void StopBusAndShow(string msg, string btnA, string btnB)
    {
        ToggleBus(false);
        ShowPopup(msg, btnA, btnB);
    }

    public void ShowPopup(string message, string choiceA, string choiceB)
    {
        eventPanel.SetActive(true);
        eventText.text = message;
        buttonAText.text = choiceA;
        buttonBText.text = choiceB;
        Time.timeScale = 0;
    }

    public void ClosePopup()
    {
        eventPanel.SetActive(false);
        Time.timeScale = 1; 
        ToggleBus(true);    
    }

    void ToggleBus(bool isMoving)
    {
        foreach (BusScroll bg in backgrounds)
        {
            if (bg != null) bg.enabled = isMoving;
        }
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSecondsRealtime(delay); 
        SceneManager.LoadScene(sceneName);
    }
}