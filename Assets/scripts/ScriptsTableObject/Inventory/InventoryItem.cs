using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.iOS;

[CreateAssetMenu(fileName ="Newitem" , menuName ="Inventory/Item")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemId;  // ID duy nhất của vật phẩm
    public string itemName;  // Tên vật phẩm
    public string itemDescription; // mô tả vật phẩm

    public Sprite itemSprite;  // ảnh vật phẩm

    public PlayerInventory playerInventory;  // Tham chiếu đến kho đồ của người chơi để có thể cập nhật số lượng khi dùng item

    public bool usable;  // item có dùng được kh

    public bool unique;  // Item có độc nhất kh (1 cái di nhất)

    public UnityEvent useEvent;  // Sự kiện khi dùng item

    public void Use()
    {
        if(useEvent != null)
        {
            
            useEvent.Invoke();
        }
    }

    public void DecreaseNumberHeld(int amout)
    {
        var numberHeld = playerInventory.myIventoryData.FirstOrDefault(t => t.ItemId == itemId);
        if(numberHeld != null)
        {
           
            numberHeld.numberHeld -= amout;
            if(numberHeld.numberHeld < 0)
            {
                numberHeld.numberHeld = 0;
            }
        }
        
    }
}
