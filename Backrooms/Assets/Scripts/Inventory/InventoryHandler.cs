using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject inventoryUI;  // Attach your inventory panel in the Unity inspector.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("InventoryOpen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryUI.SetActive(true);
        }
        else
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("InventoryClosed");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryUI.SetActive(false);
        }
    }

    public void AddItem(GameObject item)
    {
        // This is a simplified version. You might want to loop through the inventory
        // to find an empty slot, instantiate the item prefab there, etc.
        Instantiate(item, inventoryUI.transform);
    }

    public void RemoveItem(GameObject item)
    {
        // This is a simplified version. You would probably want to
        // destroy the item instance and remove it from the inventory.
        Destroy(item);
    }
}
