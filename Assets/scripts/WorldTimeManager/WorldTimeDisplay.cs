using System;
using TMPro;
using UnityEngine;

public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]private TMP_Text TimeClock;
    public WorldTime _worldTime;
    

    void Awake()
    {
       if (_worldTime != null)
        {
            _worldTime.WorldTimeChange += OnWordTimeChange;
        }
    }

    

    private void OnDestroy()
    {
        if (_worldTime != null && this != null)
        {
            _worldTime.WorldTimeChange -= OnWordTimeChange;
        }
    }

    private void OnWordTimeChange(object sender, TimeSpan NewTime)
    {
        if (TimeClock == null) return;
        TimeClock.SetText(NewTime.ToString(@"hh\:mm"));  // Giờ/phút 
    }
}
