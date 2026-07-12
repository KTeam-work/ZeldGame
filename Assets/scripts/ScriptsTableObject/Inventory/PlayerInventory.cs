using System.Collections.Generic;
using UnityEngine;

// Vì sao chọn ScriptableObject là muốn khi vào cảnh khác thì có thể điều chỉnh lại kho đồ
[CreateAssetMenu(fileName ="new Inventory",menuName ="Inventory/PlayerInventory")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myIventory = new List<InventoryItem>();

    public List<InventoryItemData> myIventoryData = new List<InventoryItemData>();

    public void AddItem(string itemId, int numberHeld)
    {
        foreach(var item in myIventoryData)
        {
            if(item.ItemId == itemId)
            {
                item.numberHeld += numberHeld;
                return;
            }
        }
       
        // Nếu không tìm thấy item nào có id trùng với itemId thì sẽ tạo một item mới và thêm vào list
        myIventoryData.Add(new InventoryItemData(itemId, numberHeld));
    }
}
