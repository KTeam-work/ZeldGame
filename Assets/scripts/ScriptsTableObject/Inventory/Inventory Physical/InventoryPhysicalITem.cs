using Unity.VisualScripting;
using UnityEngine;

public class InventoryPhysicalITem : MonoBehaviour
{
    [SerializeField] private PlayerInventory PInventory;
    [SerializeField] private InventoryItem thisItem;
    [SerializeField] private InventoryMangager inventoryMangager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            AddToInventory();
            Destroy(this.gameObject);
        }
    }

    // Add this item to the player inventory
    public void AddToInventory()
    {
        if(PInventory && thisItem)
        {
            // if (PInventory.myIventory.Contains(thisItem))
            // {
            //     thisItem.numberHeld +=1;
            //     inventoryMangager.Clearslot();
            //     inventoryMangager.MakeInventorySlot();

            // }
            // else
            // {
            //     PInventory.myIventory.Add(thisItem);
            //     thisItem.numberHeld +=1;
            //     inventoryMangager.Clearslot();
            //     inventoryMangager.MakeInventorySlot();

            // }
            if (PInventory.myIventory.Contains(thisItem))
            {
                PInventory.AddItem(thisItem.itemId,1);
                inventoryMangager.Clearslot();
                inventoryMangager.MakeInventorySlot();
            }
            else
            {
                PInventory.myIventory.Add(thisItem);
                PInventory.AddItem(thisItem.itemId,1);
                inventoryMangager.Clearslot();
                inventoryMangager.MakeInventorySlot();
            }
           
           
        }
        else
        {
            Debug.LogError("Player Inventory or this Item is not assiged in the inspector.");
        }
    }
    
}
