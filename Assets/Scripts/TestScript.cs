using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class TestScript : MonoBehaviour
{
    public PlayerClass pm;
    public TMP_Text haiii;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        haiii.text = "hi";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testButton()
    {
        haiii.text = "helloo";
    }
    public void onClick()
    {
        InventoryItem apple = new InventoryItem("Apple", 10.20, 2);
        PlayerClass.addItem(apple);
        pm.m_text.text= "hi";
    }
}
