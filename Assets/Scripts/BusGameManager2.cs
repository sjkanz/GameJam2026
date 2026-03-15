using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class BusGameManager2 : MonoBehaviour
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
        TriggerDecision("The bus is back to pick you up. Will you pay the extra $2 fare?", "Pay $2", "Go Home");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            driveTimer += Time.deltaTime;
        }

        if (driveTimer > 6f && !stopTriggered) 
        {
            stopTriggered = true; 
        
            StopBusAndShow(
                "PHONE ALERT FROM ELSTER: She says if you aren't on Roblox in the next 10 minutes, they're starting without you.", 
                "Keep Going", 
                "Go Home & Play"
            );
        
            //StartCoroutine(WaitAndLoad("RestaurantCutscene", 5f));
        }
    }

    public void OnClickA()
    {
        if (driveTimer < 1f) {
            GameManager.playerMoney -= 2; 
            Debug.Log("Paid fare. Money left: " + GameManager.playerMoney);
            ClosePopup();
        }
        else if (stopTriggered) {
            ClosePopup();
            StartCoroutine(WaitAndLoad("RestaurantCutscene", 3f));
        }
    }

    public void OnClickB() 
    {
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