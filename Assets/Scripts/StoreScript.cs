using UnityEngine;

public class StoreScript : MonoBehaviour
{
    private PlayerClass player;

    [Header("Inventory References")]
    public InventoryManager invManager;

    [Header("Item Prefabs")]
    public GameObject badApplePrefab;
    public GameObject mehApplePrefab;
    public GameObject goodApplePrefab;
    public GameObject badBananaPrefab;
    public GameObject mehBananaPrefab;
    public GameObject goodBananaPrefab;
    public GameObject applePiePrefab;
    public GameObject chipsPrefab;
    public GameObject ramenPrefab;
    public GameObject rawFishPrefab;
    public GameObject eggPrefab;


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
        invManager.AddToInventory(goodApplePrefab);
    }

    public void purchaseMehApple()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Apple", 1, 3);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(mehApplePrefab);
    }

    public void purchaseBadApple()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Apple", 0.75, 1);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(badApplePrefab);

    }

    public void purchaseApplePie()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Apple Pie", 17, 2);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(applePiePrefab);
    }

    public void purchaseGoodBanana()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Banana", 2, 5);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(goodBananaPrefab);
    }
    public void purchaseMehBanana()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Banana", 1.75, 3);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(mehBananaPrefab);
    }
    public void purchaseBadBanana()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Banana", 1.50, 3);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(badBananaPrefab);
    }
    public void purchaseChips()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Chips", 3, 2);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(chipsPrefab);
    }
    public void purchaseRamen()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Ramen", 10, 2);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(ramenPrefab);
    }
    public void purchaseRawFish()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Raw Fish", 15, 4);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(rawFishPrefab);
    }
    public void purchaseEggs()
    {
        print("purchasing...");
        InventoryItem myItem = new InventoryItem("Eggs", 5, 3);
        player.changeGroceryList(myItem);
        invManager.AddToInventory(eggPrefab);
    }
}
