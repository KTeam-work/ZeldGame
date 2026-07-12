using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

public class WorldChangeUIClock : MonoBehaviour
{
    public WorldTime _worldTime;
    
    [SerializeField] public List<Schudle> TimeSchudle;
    
    void Awake()
    {
        _worldTime.WorldTimeChange += OnChangeUiClock;
    }

    private void OnChangeUiClock(object sender, TimeSpan e)
    {
        // đúng giờ thì thay đổi
        var time = TimeSchudle.FirstOrDefault(t => t.Hours == e.Hours && t.Mintues == e.Minutes);

        time?._event?.Invoke();
    }

    void OnDestroy()
    {
        _worldTime.WorldTimeChange -= OnChangeUiClock;
    }
    
    
}
