using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject,ISerializationCallbackReceiver
{
   public float intiualValue;
   public float Point;

   [HideInInspector]
   public float Runtime;

  
   

   public void OnBeforeSerialize() // Chạy trước khi lưu dữ liệu
   {
      
   }

   public void OnAfterDeserialize()
   {
      Runtime = intiualValue;
     
   }  // Chạy sau khi lưu dữ liệu
   
}
