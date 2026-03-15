using UnityEngine;
using TMPro;


public class ApplePieRestScript: MonoBehaviour
{
    private InventoryItem myItem;
    public TMP_Text price; //assign by dragging and dropping
    public GameObject go; //assign by dragging and dropping
    private PlayerClass player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cost 75 cents bc at food vendor
        myItem = new InventoryItem("Apple Pie", 2, 5);
        myItem.setGameObject(go); // gameObject is the gameObject that this script is attached to
        price.text = myItem.getPrice().ToString();
        PlayerCreator c = new PlayerCreator();
        player = c.getPlayer();
    }


    //Purchase when clicked
    public void purchasePie()
    {
        print("purchasing...");
        player.changeGroceryList(myItem);
    }
}
