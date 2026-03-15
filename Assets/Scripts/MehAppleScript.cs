//MehApple - Food Vendor
using UnityEngine;
using TMPro;


public class MehAppleScript : MonoBehaviour
{
    private InventoryItem myItem;
    public TMP_Text price; //assign by dragging and dropping
    private PlayerClass player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cost 75 cents bc at food vendor
        myItem = new InventoryItem("Apple", 0.75, 3);
        myItem.setGameObject(gameObject); // gameObject is the gameObject that this script is attached to
        price.text = myItem.getPrice().ToString();
        PlayerCreator c = new PlayerCreator();
        player = c.getPlayer();
    }


    //Purchase when clicked
    public void purchaseMehApple()
    {
        player.changeGroceryList(myItem);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
