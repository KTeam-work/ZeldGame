using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class RomMove : MonoBehaviour
{

    public CinemachineConfiner2D confier;
    
    
    // Muốn Thay Đổi Kích Thước Của CameRa Và Nhân Vật Khi Qua Phòng Khác
    public Vector2 CamChange;

    public Vector3 HumanChange;

    private CameraFllow cam;
    

    public Vector2 MinRom2;

    // Để Hiện Chữ Khi Qua Bản Đồ Mới
    private bool  Ischange = false;
    public ScrenFade  fade;
    
    public GameObject Rom;
    private PolygonCollider2D poly;
    
    public GameObject Player;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         // cam = Camera.main.GetComponent<CameraFllow>();
        poly = Rom.GetComponent<PolygonCollider2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm Tra Trạng Thái Có Trạm Vô Chưa
        if (other.CompareTag("Player") && !Ischange)
        {
           StartCoroutine(ChangeRom(Player.transform));
        }
    }

    // IEnumerator là để chạy song song và Cho Biến Mất Trong Ít Thời Gian
    private IEnumerator ChangeRom(Transform other)
    {
        var vcam = confier.GetComponent<CinemachineVirtualCameraBase>(); 
        Ischange = true; 
        
        yield return StartCoroutine(fade.FadeOut()); // Tối màn hình

        Vector3 delta = HumanChange;
        other.position += delta;
        // BƯỚC 1: Lưu Damping cũ và ép về 0 để không bị "lố đà"
        float originalDamping = confier.Damping;
        confier.Damping = 0;

        // BƯỚC 2: Cập nhật khung Polygon mới
        confier.BoundingShape2D = poly;
        confier.InvalidateBoundingShapeCache();

        // BƯỚC 3: Dịch chuyển Player
        

        // BƯỚC 4: Ép Camera nhảy theo Player (Warp)
        confier.OnTargetObjectWarped(vcam, other, delta);

        // CHỜ: Đợi cho đến khi hệ thống vật lý và camera đồng bộ xong
        yield return new WaitForEndOfFrame();

        // BƯỚC 5: Trả lại Damping để khi di chuyển bình thường vẫn mượt
        confier.Damping = originalDamping;

        yield return StartCoroutine(fade.FadeIn()); // Sáng màn hình
        Ischange = false;
        
    }
}
