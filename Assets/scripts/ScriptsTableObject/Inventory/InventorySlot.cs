using UnityEngine;
using TMPro;

using UnityEngine.UI;
using System.Linq;
public class InventorySlot : MonoBehaviour
{
    [Header("")]
    [SerializeField] private TMP_Text itemNumberText;
    [SerializeField] private Image itemImage;


    [Header("Variable for the Item")]
    public InventoryItem thisItem;
    public InventoryMangager thisManager;
    public PlayerInventory playerInventory;

    public void SetUp(InventoryItem newItem, InventoryMangager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;

        if (thisItem)
        {
            itemImage.sprite = thisItem.itemSprite;
            int numberHeld = playerInventory.myIventoryData.FirstOrDefault(t => t.ItemId == thisItem.itemId)?.numberHeld ?? 0;
            itemNumberText.text = "" + numberHeld;
        }
    }


    public void ClickItem()
    {
        if (thisItem && thisManager) // Nếu có item và có manager thì mới gọi hàm use item
        {
            thisManager.UseItem(thisItem.itemDescription,thisItem.usable,thisItem);
        }
    }
}
