using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;


public enum DoorType
{
    key,  // Là cửa có chìa khoá
    enemy, // Là cửa có quái
    button // Cửa có nút bấm
}

public class RomDoor : InteracTabel
{
    [SerializeField] private DoorType Thisdoor;

    public bool Isopen = false;

    public Invetory PlayerIve;  // Vật phẩm của người chơi
    
    // Muốn cho cửa biến mất khi có khoá và vô hiệu va chạm   
    public BoxCollider2D DoorBox;

    public SpriteRenderer DoorSprite;
    public GameObject gameActive;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerIs) // Nếu Player Đang Đúng Trong Vùng
            {
                // Kiểm Tra Người Chơi Có Chìa Khoá Không và kiểm tra cửa cần chìa khoá
                if(PlayerIve.MaxItem > 0 && Thisdoor == DoorType.key)
                { 
                    // Xoá Chìa Khoá
                    PlayerIve.MaxItem --;                 
                    // Mở cửa 
                    OpenDoor();
                    gameActive.SetActive(true);

                }
            }
        }
    }


    public void OpenDoor()
    {
        DoorBox.enabled = false;

        DoorSprite.enabled = false;
        Isopen = true;
        this.gameObject.SetActive(false);
        
    }

    public void CloseDoor()
    {
        DoorBox.enabled = true;

        DoorSprite.enabled = true;
        Isopen = false;
    }
}
