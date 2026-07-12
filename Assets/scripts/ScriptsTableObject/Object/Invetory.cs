using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Invetory : ScriptableObject
{
   public Item CurrItem;
   public List<Item> Litems = new List<Item>();  // Chứa Các Danh sách Vật Phẩm
   public int MaxItem;
   [Header("Phần của Slider Magic")]
   public float Maxslider = 10;
   public FloatValue SliderPoint;
    void OnEnable()
    {
        if(SliderPoint.Point == 0)
        {
            Debug.Log("Nhận giá trị");
            SliderPoint.Point = Maxslider;
            Debug.Log(SliderPoint.Point);
        }
        
    }

     

    public void ReducerMagic()
    {
        SliderPoint.Point -= 1;
    }

    [SerializeField] public int CoinPoint;

    // Check Bow  
    public bool CheckBow(Item items)
    {
        if (Litems.Contains(items))
        {
            return true;
        }
        return false;
    }

   public void AddItem(Item item)
    {
        if (item.isKey)
        {
            MaxItem++;
        }
        else
        {
            if (!Litems.Contains(item))  // Nếu không có thì thêm item này vào
            {
                Litems.Add(item);
            }
        }
    }

}
