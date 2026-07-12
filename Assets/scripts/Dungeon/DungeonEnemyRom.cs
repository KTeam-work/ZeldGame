using UnityEngine;

public class DungeonEnemyRom : DungeonRom
{
   // Thuộc Tính Door
   public RomDoor[] Doors;
   

   // Phát Tín Hiệu Khi Vào Lại
   public void CheckEnemy()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }
            
        }
        OpenDoorEnemy(); // Khi Giết hết quái sẽ Return
    }

   // Xử Lí Override
   public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActive(enemies[i],true);
            }

            for(int i =0; i < Pots.Length; i++)
            {
                ChangeActive(Pots[i],true);
            }
            CloseDoorEnemy();  // Đóng Cửa Khi Enemy vào
        }
        
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActive(enemies[i],false);
            }

            for(int i =0; i < Pots.Length; i++)
            {
                ChangeActive(Pots[i],false);
            }
        }
    }


    // Hàm Open
    void OpenDoorEnemy()
    {
        for(int i =0; i < Doors.Length; i++)
        {
            Doors[i].OpenDoor();  // Mở tất cả cửa
        }
    }
    
    // Hàm Close
    void CloseDoorEnemy()
    {
        for(int i =0; i < Doors.Length; i++)
        {
            Doors[i].CloseDoor(); // Tắt tất cả cửa
        }
    }




}
