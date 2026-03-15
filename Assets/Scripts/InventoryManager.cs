using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryGrid;

    public void AddToInventory(GameObject itemPrefab)
    {
        if (inventoryGrid == null) return;

        GameObject newItem = Instantiate(itemPrefab);
        newItem.transform.SetParent(inventoryGrid, false);
        foreach (Transform child in inventoryGrid.GetComponentsInChildren<Transform>(true))
        {
            Debug.Log("hello");
            child.gameObject.SetActive(true);
        }

        // Button buyBtn = .GetComponentInChildren<Button>();
        // if (buyBtn != null) buyBtn.gameObject.SetActive(false);
    }
}