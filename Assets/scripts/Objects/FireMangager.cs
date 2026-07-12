using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireMangager : GenericWorldTime
{
    [SerializeField] private List<Schudle> mySchudle;
    
    public void Awake()
    {
        _worldTime.WorldTimeChange += ChangeFire;
    }

    private void ChangeFire(object sender, TimeSpan e)
    {
        var Fire = mySchudle.FirstOrDefault(t => t.Hours == e.Hours && t.Mintues == e.Minutes);

        Fire?._event?.Invoke();
    }
}
