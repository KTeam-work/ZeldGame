using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameSaveData
{
    public List<string> list_sctiptableObject = new List<string>();

    public List<string> List_Inventory = new List<string>();

    public long tick;
    
    public Vector3 _playerPosition;
}
