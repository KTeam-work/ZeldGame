using UnityEngine;

[System.Serializable]
public class InventoryItemData
{
   public string ItemId;
   public int numberHeld;

   public InventoryItemData(string itemId, int numberHeld)
   {
       ItemId = itemId;
       this.numberHeld = numberHeld;
   }

   public InventoryItemData()
   {
       ItemId = "";
       this.numberHeld = 0;
   }
}
