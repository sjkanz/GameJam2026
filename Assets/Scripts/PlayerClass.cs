using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;


public class PlayerClass : MonoBehaviour
{
    public double currFunds = 100;
    public double busFare = 5;
    public InventoryClass inventory;
    public int totalNutrition = 0;

    //variables for grocery list
    public static List<InventoryItem> needToBuy = new List<InventoryItem>();
    public static List<InventoryItem> wantToBuy = new List<InventoryItem>();
    private TMP_Text m_text;

    // private string list;

    private static bool updateNeeded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        inventory = new InventoryClass();

        //initializing needToBuy list
        needToBuy.Add(new InventoryItem("Apple"));
        needToBuy.Add(new InventoryItem("Banana"));
        needToBuy.Add(new InventoryItem("1 meal (ex: Ramen, hot dog, cooked fish)"));

        //initializing wantToBuy list
        wantToBuy.Add(new InventoryItem("Apple pie"));
        wantToBuy.Add(new InventoryItem("Chips"));
        wantToBuy.Add(new InventoryItem("Eggs"));

        //text component
        m_text = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        print("in else");
        m_text.autoSizeTextContainer = true;

        //set text
        m_text.text = toString();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateNeeded) {
            m_text.SetText(toString());
            updateNeeded = false;
        }
    }

    //methods

    /*
     * print grocery list in string format
    */
    public string toString()
    {
        string done = "Need to Buy:\n";
        //adding needToBuy
        foreach (InventoryItem item in needToBuy)
        {
            if (inventory.Contains(item))
            {
                done += "☑︎" + item.itemName + "\n";
            }
            else {
                done += "☐" + item.itemName + "\n";
            }
        }
        //adding wantToBuy
        done += "Want to Buy:\n";
        foreach (InventoryItem item in wantToBuy)
        {
            if (inventory.Contains(item))
            {
                done += "☑︎" + item.itemName + "\n";
            }
            else {
                done += "☐" + item.itemName + "\n";
            }
        }
        print("final string: " + done);
        return done;
    }

    public void setUpdateNeeded(bool holder)
    {
        updateNeeded = holder;
    }

    /*
     * pay the bus fare
     */
    public void payBusFare()
    {
        currFunds -= busFare;
        print("Successfully paid bus fare");
    }

    /*
     * add an item to inventory list
     */

    public void addItem(InventoryItem item)
    {
        inventory.AddItem(item);
        currFunds -= item.getPrice();
        totalNutrition += item.nutritionValue;
        setUpdateNeeded(true);
        print("Successfully bought: " + item.itemName);
    }

    public void removeItem(InventoryItem item)
    {
        inventory.removeItem(item);
        currFunds += item.getPrice();
        totalNutrition -= item.nutritionValue;
        setUpdateNeeded(true);
        print("Successfully removed: " + item.itemName);
    }

    // public bool boughtItem(InventoryItem item)
    // {
    //     return inventory.Contains(item);
    // }

}
