using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private static GameManager _instance;
    [SerializeField] private Transform _playerPosition;

    [Header("Data Manager")]
    public GameSaveManger _gameSaveManger;
    public InventorySaver _inventorySaver;

    [Header("SenceManager")]
    public TimeUiClockSaver _timeUiClockSaver;
    
    [Header("Available Sences")]
    private long tick;


    // Dùng singleton để quản lý GameManager
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this; 
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else if(_instance != this)
        {
           
            Destroy(this.gameObject);
        }
      
    }

   

    private void OnDestroy()
    {
      
        if (_instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _instance = null;
        }
    }

    void Start()
    {
        if(_instance == this)
        {
            LoadGame();
        }
    }


    private void OnSceneLoaded(Scene _scene, LoadSceneMode _loadSenceMode)
    {

        _timeUiClockSaver = FindAnyObjectByType<TimeUiClockSaver>();
        if(_timeUiClockSaver != null)
        {
           
            TimeSpan newTime = new TimeSpan(tick);
            _timeUiClockSaver.SetWorldTime(newTime,_playerPosition);
        }
        
    } 

    public void SetSence(Vector2 newPosition) 
    {
        WorldTime _worldTime = FindAnyObjectByType<WorldTime>();
        if(_playerPosition != null)
        {
            _playerPosition.position = newPosition;
        }
       
        if(_worldTime != null)
        {
           tick = _worldTime.CurrentTime._timeSpan.Ticks;
          
        }
    }

    public void SaveGame()
    {
        DeleteSave();
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath+ string.Format("/{0}.Game",1);
        
        List<ScriptableObject> list_scriptableObjects = _gameSaveManger.GetList();
        PlayerInventory pInventory = _inventorySaver.GetPlayerInventory();
        WorldTime worldTime = _timeUiClockSaver.GetWorldTime();

        GameSaveData temp = new GameSaveData();
        
        // Lưu List ScriptableObject
        foreach (var item in list_scriptableObjects)
        {
            string json = JsonUtility.ToJson(item);
            temp.list_sctiptableObject.Add(json);
        }

        // Lưu List Inventory
        foreach (var item in pInventory.myIventoryData)
        {
            string json = JsonUtility.ToJson(item);
            temp.List_Inventory.Add(json);
        }

        // Lưu Time
        temp.tick = worldTime.CurrentTime._timeSpan.Ticks;
        
        // Lưu Position
        temp._playerPosition = _playerPosition.position;

        string json_temp = JsonUtility.ToJson(temp);
        File.WriteAllText(path,json_temp);
     

    }


    public void LoadGame()
    {
        string path = Application.persistentDataPath+ string.Format("/{0}.Game",1);
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameSaveData temp = JsonUtility.FromJson<GameSaveData>(json);

            // Load List ScriptableObject
            for(int i =0; i < temp.list_sctiptableObject.Count; i++)
            {
                if(temp.list_sctiptableObject[i] != null)
                {
                    JsonUtility.FromJsonOverwrite(
                        temp.list_sctiptableObject[i],
                        _gameSaveManger.list[i]
                    );
                }
            }
           
            if(temp.List_Inventory != null)
            {
                _inventorySaver.ClearInventory();
            }
            // Load List Inventory
            for(int i =0; i < temp.List_Inventory.Count; i++)
            {
                if(temp.List_Inventory[i] != null)
                {
                    InventoryItemData src = new InventoryItemData();
                    JsonUtility.FromJsonOverwrite(temp.List_Inventory[i],src);
                    _inventorySaver.AddInventory(src);
                }
            }
            
            this.tick = temp.tick;

            // Load Time
            TimeSpan newTime = new TimeSpan(temp.tick);
            _timeUiClockSaver.SetWorldTime(newTime,_playerPosition);
            
        }
    }

    public void DeleteSave()
    {
        if(File.Exists(Application.persistentDataPath+ string.Format("/{0}.Game", 1)))
        {
            File.Delete(Application.persistentDataPath+string.Format("/{0}.Game",1));
        }
    }
}

