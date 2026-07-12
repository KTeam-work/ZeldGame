using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManger : MonoBehaviour
{

    public List<ScriptableObject> list = new List<ScriptableObject>();

    // Return List
    public List<ScriptableObject> GetList()
    {
        return list;
    }

    public void AddList(int index,ScriptableObject sct)
    {
        list[index] = sct;
    }
    
   
}
