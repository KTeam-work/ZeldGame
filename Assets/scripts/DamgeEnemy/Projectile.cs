using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Vật Thể")]
    public Rigidbody2D Myrigi;
    [Header("TimeSurvois")]
    public float LifeTime; // Thời Gian Sống Tổi Thiểu
    private float LifeTimeSecond;

    public float Speed;
    void Start()
    {
        LifeTimeSecond = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
      
      
    }


    public void Launch(Vector2 Vitri)  // Tốc độ bắn của viên đạn
    {
        if (Myrigi)
        {
            Myrigi.linearVelocity = Vitri.normalized * Speed;
            Destroy(gameObject,LifeTime);
        }
    }
    
    // Nếu bắn trúng thì phá huỷ
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Destroy(this.gameObject);
        }
    }
}
