using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinalScene : MonoBehaviour
{
    public GameObject clickPromptText;

    public void OnScreenClicked()
    {
        if (clickPromptText != null) 
        {
            clickPromptText.SetActive(false);
        }
        
        DetermineEnding();
    }

    public void DetermineEnding()
    {
        //did they get all the food?
        bool gotApple = false;
        bool gotBanana = false;
        bool gotMeal = false;
        foreach (InventoryItem item in PlayerClass.needToBuy)
        {
            if (PlayerClass.inventory.Contains(item))
            {
                InventoryItem apple = new InventoryItem("Apple");
                InventoryItem banana = new InventoryItem("Banana");
                //doing if statements to count purchasing only once
                if (item.equals(apple))
                {
                    gotApple = true;
                } else if (item.equals(banana))
                {
                    gotBanana = true;
                } else
                {
                    //checking if meal
                    InventoryItem hotdog = new InventoryItem("Hot dog");
                    InventoryItem cookedFish = new InventoryItem("Cooked Fish");
                    InventoryItem ramen = new InventoryItem("Ramen");
                    if (item.equals(hotdog) || item.equals(cookedFish) || item.equals(ramen))
                    {
                        gotMeal = true;
                    }
                }
            }
        }
        //boolean for all
        bool gotAllFood = gotApple && gotBanana && gotMeal;
        
        //load scenes
        if (GameManager.getScore() >= 10 && gotAllFood) 
        {
            SceneManager.LoadScene("BestEndingHomeScreen");
        }
        else if (GameManager.getScore() >= 5 && gotAllFood) 
        {
            SceneManager.LoadScene("MidEndingHomeScreen");
        }
        else 
        {
            SceneManager.LoadScene("FailedEndingHomeScreen");
        }
    }
}