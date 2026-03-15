using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;


public class PlayerClass : MonoBehaviour
{
    public static double currFunds = 100;
    public static double busFare = 5;
    public static InventoryClass inventory;
    public static int totalNutrition = 0;

    //variables for grocery list
    public static List<InventoryItem> needToBuy = new List<InventoryItem>();
    public static List<InventoryItem> wantToBuy = new List<InventoryItem>();
    public TMP_Text m_text;

    // public string msg;

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
        // m_text = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        // print("in else");
        // m_text.autoSizeTextContainer = true;

        //set text
        // msg = toString();
        m_text.text = toString();

    }

    // Update is called once per frame
    void Update()
    {
    }


    /* BUTTON TESTING LOGIC */
    public void changeGroceryList(InventoryItem item)
    {
        // InventoryItem apple = new InventoryItem("Apple", 10.20, 2);
        addItem(item);
        string holder = toString();
        // Debug.Log(holder);
        m_text.text = holder;
        print("after .text call");
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
                done += "X " + item.itemName + "\n";
            }
            else
            {
                done += "☐" + item.itemName + "\n";
            }
        }
        //adding wantToBuy
        done += "Want to Buy:\n";
        foreach (InventoryItem item in wantToBuy)
        {
            if (inventory.Contains(item))
            {
                done += "X " + item.itemName + "\n";
            }
            else
            {
                done += "☐" + item.itemName + "\n";
            }
        }
        print("final string: " + done);
        return done;
    }

    public static void setUpdateNeeded(bool holder)
    {
        updateNeeded = holder;
    }

    /*
     * pay the bus fare
     */
    public static void payBusFare()
    {
        currFunds -= busFare;
        print("Successfully paid bus fare");
    }

    /*
     * add an item to inventory list
     */

    public static void addItem(InventoryItem item)
    {
        print(item.itemName + "\n");
        inventory.AddItem(item);
        currFunds -= item.getPrice();
        totalNutrition += item.nutritionValue;
        // setUpdateNeeded(true);
        print("Successfully bought: " + item.itemName);
    }

    public static void removeItem(InventoryItem item)
    {
        inventory.removeItem(item);
        currFunds += item.getPrice();
        totalNutrition -= item.nutritionValue;
        setUpdateNeeded(true);
        print("Successfully removed: " + item.itemName);
    }

    public static void removeRecent()
    {
        int index = inventory.GetList().Count - 1;
        InventoryItem holder = inventory.GetList()[index];
        inventory.GetList().RemoveAt(index);
        currFunds += holder.getPrice();
        totalNutrition -= holder.nutritionValue;
        print("Successfully removed: " + holder.itemName);
    }



    // public bool boughtItem(InventoryItem item)
    // {
    //     return inventory.Contains(item);
    // }

}
