using UnityEngine;
using System.Collections.Generic;
using System;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public double price;
    public int nutritionValue;
    private GameObject gameObject; //game object assocaited with this inventory data

    // Constructors for InventoryItem
    public InventoryItem(string name, double prc, int nutrients)
    {
        itemName = name;
        price = prc;
        nutritionValue = nutrients;
    }

    //GroceryList Contructor
    public InventoryItem(string name)
    {
        itemName = name;
        price = 0;
        nutritionValue = 0;
    }

    public double getPrice()
    {
        return price;
    }

    public bool equals(InventoryItem item2)
    {
        //only comparing strings to remove technical discrepancies (ie, for grocery list, bad apple technically equals good apple)
        return this.itemName.Equals(item2.itemName, StringComparison.OrdinalIgnoreCase);
    }

    public void setGameObject(GameObject go)
    {
        gameObject = go;
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}

public class InventoryClass : MonoBehaviour
{
    private List<InventoryItem> inventoryItems; //list of items currently in player inventory
    int maxNumItems = 5; //max num of items is 5
    int currentItemCount = 0; //number of items currently in inventory

    public InventoryClass()
    {
        inventoryItems = new List<InventoryItem>(); //initializing empty list
    }

    //methods

    /*
    * @Method add an item to the inventory list
    * @Return true if successful, false otherwise
    */
    public bool AddItem(InventoryItem item)
    {
        if (currentItemCount == maxNumItems)
        {
            print("Cannot add item - too many!");
            return false;
        }
        //adding item
        inventoryItems.Add(item);
        currentItemCount++;
        return true;
    }

    /*
    * @Method remove item parameter from inventory list
    * @Return True if successful, False otherwise
    */
    public void removeItem(InventoryItem item)
    {
        //removing item
        inventoryItems.Remove(item);
        currentItemCount--;
    }

    /*
    * get access to the inventory list
    */
    public List<InventoryItem> GetList()
    {
        return inventoryItems;
    }

    public bool Contains(InventoryItem item)
    {
        InventoryItem check = new InventoryItem("1 meal (ex: Ramen, hot dog, cooked fish)");
        if (item.equals(check))
        {
            //if this is supposed to represent one meal, check if there exists ramen, cooked fish, or hot dog
        }
        //return inventoryItems.Contains(item);
        //must iterate through to compare the names
        foreach (InventoryItem inven in inventoryItems)
        {
            if (inven.equals(item))
            {
                return true;
            }
        }
        return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
