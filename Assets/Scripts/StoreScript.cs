using UnityEngine;

public class StoreScript : MonoBehaviour
{
    private PlayerClass player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCreator c = new PlayerCreator();
        player = c.getPlayer();
    }

    public void purchaseGoodApple()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Apple", 2, 5);
        player.changeGroceryList(myItem);
    }

    public void purchaseMehApple()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Apple", 1, 3);
        player.changeGroceryList(myItem);
    }
}
