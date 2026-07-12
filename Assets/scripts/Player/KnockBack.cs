using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.Rendering;

public class KnockBack : GenericDamge
{

    public float thurst; // Để Tác Động Lực Có Văng Xa Không
    public float ThoiGianDung;
    // private float Damge;
    
    // public PlayerStatus P;

    
   
    void Awake()
    {
        // Damge = P.damge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("BreakPot"))
        {
            
            other.GetComponent<Pot>().DestoryPot();
        }

        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
           
            Rigidbody2D Hit = other.GetComponent<Rigidbody2D>(); // Lấy cái vật thể bật chạm của Enemy
            if(Hit != null)
            {
                Hit.bodyType = RigidbodyType2D.Dynamic; 
                Vector2 diffent = Hit.transform.position - transform.position; // Điểm đích trừ điểm đi
                diffent = diffent.normalized * thurst;  // Phải Chuẩn Hoá Nếu nó tấn công xéo thì nó nhanh hơn
                Hit.AddForce(diffent,ForceMode2D.Impulse); // ForceMove2d.Impulse là dùng để di chuyển nhanh tất thì

                if (other.CompareTag("Enemy"))
                {
                    Enemy enemy = Hit.GetComponent<Enemy>();
                    enemy.TakeDamge(damageAmount); // Gọi phương thức nhận sát thương
                    Hit.GetComponent<Enemy>().CurrState = EnemyState.Stagger; // Khi Bị Chém Thì Nó Bị Choáng
                    Hit.GetComponent<Enemy>().CheckThoiGian(Hit,ThoiGianDung);
                }

              
                if (other.CompareTag("Player")) // Nếu Không Phải Choáng Thì Mới Tấn Công
                {
                    Debug.Log("Chạm trúng người chơi");
                    GenericHealth otherHealth = other.GetComponentInChildren<GenericHealth>();
                    if (otherHealth)
                    {
                        Hit.GetComponent<PlayerMonover>().Currstate.CurrPlayerState = Statemachine.PlayerState.stagger;
                        Hit.GetComponentInChildren<PlayerHealth>().PlayerStagger(ThoiGianDung,Hit); // Khi Bị Chém Thì Nó Bị Choáng
                        otherHealth.TakeDamage(damageAmount); // Gọi phương thức nhận sát thương
                    }
                        
                }
                
              
               
            }
        }
    }

   
}


