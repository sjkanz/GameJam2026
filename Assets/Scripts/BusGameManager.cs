using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class BusGameManager : MonoBehaviour
{
    public GameObject eventPanel;
    public TMP_Text eventText;
    public int playerMoney = 15; 
    public BusScroll[] backgrounds; 
    public TMP_Text buttonAText; 
    public TMP_Text buttonBText;
    public int currentStop = 0;
    private float driveTimer = 0f;

    bool isPaused = false;

    void Start()
    {
        TriggerDecision("You've boarded the bus. Will you pay the $2 fare?", 2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (backgrounds == null || backgrounds.Length == 0) return;
        if (Time.timeScale > 0)
        {
            driveTimer += Time.deltaTime;
        }
        // okay stop bus after 5 seconds
        if (currentStop == 1 && driveTimer > 5f) 
        {
            currentStop = 2; 
            StopBusAndShow("TRAFFIC JAM AHHHH! Wait or Go Back?", "Wait", "Go Back");
            StartCoroutine(TrafficJamSequence());
            //SceneManager.LoadScene("ConvenienceCutscene");
            
        }
        // next stop after 15 seconds
        if (currentStop == 2 && driveTimer > 15f)
        {
            currentStop = 3; 
            StopBusAndShow("ARRIVED: Food Vendor. Get off here?", "Get Off", "Keep Riding");
            SceneManager.LoadScene("ConvenienceCutscene");
        }
    }

    public void ShowPopup(string message, string choiceA, string choiceB)
    {
        if (eventPanel != null) eventPanel.SetActive(true);
        if (eventText != null) eventText.text = message;
        if (buttonAText != null) buttonAText.text = choiceA;
        if (buttonBText != null) buttonBText.text = choiceB;
        Time.timeScale = 0; 
    }

    void StopBusAndShow(string msg, string btnA, string btnB)
    {
        ToggleBus(false);
        ShowPopup(msg, btnA, btnB);
    }

    public void TriggerDecision(string message, int cost)
    {
        ToggleBus(false);
        if (eventPanel != null) eventPanel.SetActive(true);
        if (eventText != null) eventText.text = message;
        if (buttonAText != null) buttonAText.text = "Pay $2";
        if (buttonBText != null) buttonBText.text = "Go Back Home";
        Time.timeScale = 0;
    }

    public void OnClickA()
    {
        if (currentStop == 0) {
            playerMoney -= 2; 
        }
        ClosePopup();
    }

    public void OnClickB() {
        ClosePopup();
    }

    public void ClosePopup()
    {
        if (eventPanel != null) {
            eventPanel.SetActive(false);
        }
        Time.timeScale = 1; 
        ToggleBus(true);    
        currentStop++;      
    }

    void ToggleBus(bool isMoving)
    {
        if (backgrounds == null) return;
        foreach (BusScroll bg in backgrounds)
        {
            if (bg != null) bg.enabled = isMoving;
        }
    }
    private IEnumerator WaitAndResume()
    {
        isPaused = true;
        
        yield return new WaitForSeconds(5f);
        
        isPaused = false;
    }
    IEnumerator TrafficJamSequence()
    {
        StopBusAndShow("TRAFFIC JAM! Please wait...", "Stay", "Walk");
    
        yield return new WaitForSecondsRealtime(10.0f);
    
        // 3. Optional: Hide the popup before leaving
        if (eventPanel != null) eventPanel.SetActive(false);

        // 4. Switch to the new scene
        SceneManager.LoadScene("ConvenienceCutscene");
    }
}