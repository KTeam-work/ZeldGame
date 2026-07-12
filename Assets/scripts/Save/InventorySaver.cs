using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class InventorySaver : MonoBehaviour
{
    [SerializeField] private PlayerInventory pInventory;

    // Return PlayerInventory
    public PlayerInventory GetPlayerInventory()
    {
        return pInventory;
    }

    // Load Inventory data khi bật lên
    public void AddInventory(InventoryItemData data)
    {
        pInventory.myIventoryData.Add(data);
    }

    public void ClearInventory()
    {
        pInventory.myIventoryData.Clear();
    }

}
