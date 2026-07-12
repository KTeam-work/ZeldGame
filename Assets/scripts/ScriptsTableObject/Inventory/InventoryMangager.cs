using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Mathematics;
using System.Linq;
public class InventoryMangager : MonoBehaviour
{
   
    [SerializeField] private GameObject ContentInventory;  // Để set cha cho mấy cái slot
    [SerializeField] private GameObject SlotInventory;  // Là đối tương chứa các ảnh và number

    [Header("variable for description and use Button")]
    [SerializeField] private GameObject useButton;
    [SerializeField] private TMP_Text decsriptionText;

    [Header("PlayerInventory")]
    [SerializeField] private PlayerInventory playerInventory;
    
    [Header("variable for item")]
    [SerializeField] private InventoryItem CurrentItem;

    public void MakeInventorySlot()
    {
        if (playerInventory)
        {
            for(int i =0; i < playerInventory.myIventory.Count; i++)  // Duyệt tất cả trang bị
            {
                string itemId = playerInventory.myIventory[i].itemId;
                int numberHeld = playerInventory.myIventoryData.FirstOrDefault(t => t.ItemId == itemId)?.numberHeld ?? 0;
                
                if(numberHeld > 0)  // Nếu trang bị đó có trong list data thì mới tạo slot
                {
                    // tạo đối tượng slot ra ở trong content
                    GameObject temp = Instantiate(SlotInventory,ContentInventory.transform.position,quaternion.identity);
                    // gán vị trí cha cần hiện
                    temp.transform.SetParent(ContentInventory.transform);
                    InventorySlot slot = temp.GetComponent<InventorySlot>();
                    if (slot)
                    {
                        slot.SetUp(playerInventory.myIventory[i],this);
                    }
                }
                else
                {
                    SetTextAndButton("",false);
                }
            }
        }
    }

    public void SetTextAndButton(string description,bool usebutton)
    {
        decsriptionText.text = description;
        if (usebutton)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void Start()
    {
        SetTextAndButton("",false);
        MakeInventorySlot();
       
    }
    

    // Hàm này để set text và button khi click vào item
    public void UseItem(string itemđescription, bool usebutton, InventoryItem item = null)
    {
        if(itemđescription == "" && usebutton == false)  // Nếu Không có item nào được chọn thì ẩn  text và button đi
        {
            CurrentItem = null;
            SetTextAndButton("",false);
        }
        else
        {
           CurrentItem = item;
           SetTextAndButton(itemđescription, usebutton);
        }
        
    }
    
    public void Clearslot()
    {
        for(int i =ContentInventory.transform.childCount -1 ; i >= 0; i--)
        {
            Destroy(ContentInventory.transform.GetChild(i).gameObject); // Chạy qua tất cả slot con của content
        }
    }

    // Click on use button
    public void OnClickUseButton()
    {
        int numberHeld = playerInventory.myIventoryData.FirstOrDefault(t => t.ItemId == CurrentItem.itemId)?.numberHeld ?? 0;
        if (CurrentItem)
        {
            if(numberHeld > 0)
            {
                // Xoá hết các slot hiện tại đi để tạo lại sau khi dùng item
                Clearslot();
                CurrentItem.Use(); // Gọi hàm Use của item đó để thực hiện hành động
                MakeInventorySlot(); // Tạo lại slot sau khi dùng item
            }
        }
    }
}
