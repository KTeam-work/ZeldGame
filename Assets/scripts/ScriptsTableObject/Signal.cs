using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<Listener> SiganlListener = new List<Listener>();  // Sgin bị lỗi class

    public void Rasie()
    {
        

        for(int i = SiganlListener.Count - 1; i  >= 0; i--)  // Tại sao duyệt cuối 
           // Vì Nếu Có trường hợp đang duyệt xoá nó đi sẽ bị lỗi
        {
            SiganlListener[i].ARasise(); // Phát Tín Hiệu
        }
    }

    public void OnListener(Listener Other)
    {
        SiganlListener.Add(Other);
    }

    public void DisListener(Listener Other)
    {
        SiganlListener.Remove(Other);
    }

    

}
