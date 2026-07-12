using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Item : ScriptableObject
{
   public Sprite sprite;
   public bool isKey; // Kiểm Tra Này đã Tồn Tại Chưa

   public string NameItem; // Tên Của Sản Phẩm
}
