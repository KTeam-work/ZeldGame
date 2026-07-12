using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BoolValue :ScriptableObject,ISerializationCallbackReceiver
{
   public bool Invisual;


   public bool RunTime;

    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        
    }
}
