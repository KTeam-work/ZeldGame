using System;
using System.IO;
using UnityEngine;

public class TimeUiClockSaver : MonoBehaviour
{
    [SerializeField] private WorldTime _worldTime;
    [SerializeField] private PlayerPosition _playerPostion;
    [SerializeField] private Transform _Myplayer;

    // Return WorldTime
    public WorldTime GetWorldTime()
    {
        return _worldTime;
    }

    public void SetWorldTime(TimeSpan newTime, Transform playerTransform)
    {
        if(_worldTime == null)
        {
            _worldTime = FindAnyObjectByType<WorldTime>();
        }

        if (_worldTime != null && _worldTime.CurrentTime != null)
        {
            _worldTime.CurrentTime._timeSpan = newTime;
           
        }
        else
        {
           
            Debug.LogWarning("Không thể đặt thời gian vì _worldTime hoặc CurrentTime đang bị NULL ");
        }
        
        if(playerTransform != null)
        {
            _Myplayer = playerTransform;
        }
    }

}
