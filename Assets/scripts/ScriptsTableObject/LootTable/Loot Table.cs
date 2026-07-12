
using UnityEngine;

[System.Serializable]  // Phải có hàm này thì class mới hoạt động
public class Loot
{
    public PowerUp thisloot; // Đối Tượng Rơi Ra
    public int lootChance; // Số Lượng
}


[CreateAssetMenu]
[System.Serializable]
public class LootTable : ScriptableObject
{
    public Loot[] lots;

    // Tạo Hàm Rơi Vật Phẩm Đố Ra Ngoài
    public PowerUp Fallout()
    {
        // Muốn tỉ lệ là 0 ->100 
        int Point = Random.Range(0,100);
        int CurrLootChange = 0;
        for(int i = 0; i < lots.Length; i++)
        {
            CurrLootChange += lots[i].lootChance; // lấy tỉ lệ xuất hiện
            // Coin là 50 và Heart là 25
            if(Point <= CurrLootChange)
            {
                return lots[i].thisloot; // trả về cái power up
            }
        }
        return null;// nếu kh có j thì trả vè không

    }
}
