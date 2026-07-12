using System;
using Unity.Mathematics;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform Human;
    public float Speed;
    // Để cho camera không ra ngoài viền t cần 2 giá trị max min của 2 Trục
    public Vector2 MaxPos;
    public Vector2 MinPos;

    void Start()
    {
        
    }

    // Dùng Với Camera nên sài LateCamera để việc cho camera chạy sau tất cả
    void LateUpdate()
    {
        // Kiểm Tra Hiện Tại Của Camera hiện Tại so với người chơi
        if(transform.position != Human.position)
        {
            Vector3 Vitri = new Vector3(Human.position.x,Human.position.y,transform.position.z);
             
            // Dùng vector Clamp
            Vitri.x = Math.Clamp(Vitri.x,MinPos.x,MaxPos.x);
            Vitri.y = Math.Clamp(Vitri.y,MinPos.y,MaxPos.y);

            // Lerp là công thức tính nội tuyến: Begin, End, Tim
            transform.position = Vector3.Lerp(transform.position,Vitri,Speed * Time.deltaTime);
        }
    }
}
