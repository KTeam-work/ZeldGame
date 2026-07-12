using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    private Light2D _light2d;

    [SerializeField] private WorldTime _worldTime;

    public Gradient myGradient;


    void Awake()
    {
        _light2d = GetComponent<Light2D>();
        _worldTime.WorldTimeChange += OnLightChanger;
    }

    void OnDestroy()
    {
        _worldTime.WorldTimeChange -= OnLightChanger;
    }

    private void OnLightChanger(object sender, TimeSpan e)
    {
        _light2d.color = myGradient.Evaluate(PrecentOfDay(e));
    }

    private float PrecentOfDay(TimeSpan NewSpan)
    {
        // Chia loại bỏ toàn bộ số phút của mấy ngày trước chỉ để ngày hiện tại
        return (float)NewSpan.TotalMinutes % WorldTimeContainers.MinutuesInDay / WorldTimeContainers.MinutuesInDay;
    }
}
