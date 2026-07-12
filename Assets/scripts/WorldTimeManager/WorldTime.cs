using System;
using System.Collections;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> WorldTimeChange;
    
    // Sửa lại chính tả cho chuẩn: dayLength
    [SerializeField] private float dayLength;

    public TimeClass CurrentTime = new TimeClass();

    // Sửa lại theo biến đã đổi tên
    public float MinutesLength => dayLength / WorldTimeContainers.MinutuesInDay;

    private Coroutine timeCoroutine; // Giữ lại reference của Coroutine để quản lý

    void Awake()
    {
        
        // Chạy coroutine khi Object được kích hoạt
        timeCoroutine = StartCoroutine(AddMinutes());
    }

    void OnDisable()
    {
        // Đảm bảo dừng ngay Coroutine khi Object bị tắt/hủy, tránh bắn Event "ma"
        if (timeCoroutine != null)
        {
            StopCoroutine(timeCoroutine);
        }
    }

    // Sửa chính tả tên hàm luôn cho chuẩn: AddMinutes
    private IEnumerator AddMinutes()
    {
        while (true)
        {
            CurrentTime._timeSpan = CurrentTime._timeSpan.Add(TimeSpan.FromMinutes(1));
            
            // Chỉ Invoke khi game thực sự đang chạy, tránh lỗi Inspector khi bấm Stop Game
            if (Application.isPlaying)
            {
                
                WorldTimeChange?.Invoke(this, CurrentTime._timeSpan);
            }
            
            yield return new WaitForSeconds(MinutesLength);
        }
    }
}