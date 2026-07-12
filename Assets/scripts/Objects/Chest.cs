using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Chest : InteracTabel
{
    public GameObject Dailog;  // Cái Log in Ra
    public TMP_Text Text;  // Dòng Chữ
    private Animator ani; // Hành Động
    public bool ChestOpen = false;  // Để Check Có Đang Mở Không

    public Invetory Ive; // Để Thêm Item Vào

    public Item contentItem; // Vật Phẩm

    public Signal IveRaise;

    public BoolValue Check;
   

 
    void Start()
    {
        ani = GetComponent<Animator>();
        if (Check.RunTime)
        {
            ChestOpen = true;
            ani.SetBool("SenceChest",true);
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerIs)  // Nếu cái hòm nó chx mở
        {
            // Check Dk
            if (!ChestOpen)
            {
                OpenChest();
            }
            else  
            {
                CloserChest();
            }
        }
       
    }

    
    // Mở Chest
    public void OpenChest()
    {
        //Mở Diaglog
        Dailog.SetActive(true);
        // Text
        Text.text = contentItem.NameItem;
        // Animation
        ani.SetBool("ChestBool",true);
         // Thêm Item
        Ive.AddItem(contentItem);
       
        // Lưu Item
        Ive.CurrItem = contentItem; 

         // Dóng Check
        ChestOpen = true;
        ContextOn.Rasie();
        
        // Gọi Singal
        IveRaise.Rasie(); // Để Hiện Ra Cái Key
        PlayerIs = true;
        Check.RunTime = false;
    }


    public void CloserChest()
    {
        if (!Check.RunTime)
        {
             // Tắt Dialog
            Dailog.SetActive(false);

            //Tắt Invetory của Item trống đi
            Ive.CurrItem = null;

            // Tắt Singal
            IveRaise.Rasie();
            Check.RunTime = true;

        }
            
        
      
    }

    // Check Điều Kiện Khi Đã Mở Rương Không Còn Dấu Chấm Hỏi Trên Đầu
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ChestOpen)
        {
            base.OnTriggerEnter2D(collision);
        }
       
    }


    public override void OnTriggerExit2D(Collider2D collision)
    {
        
        
        if (!ChestOpen)
        {
            base.OnTriggerEnter2D(collision);
        }

       
        
    }



}
