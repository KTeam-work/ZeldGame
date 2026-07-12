using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public enum EnemyState
{
    Idle,
    Walk,
    Attack,
    Stagger // Khi Quái Bị Choáng
}


public class Enemy : MonoBehaviour
{
    public EnemyState CurrState;
    public string NameEnemy;
    private float Healt;
    public float Speed;

    public GameObject effect;
   
    public FloatValue maxHealth;
    public Vector3 PosstionRes;

    public Signal EnemyRom;

    public LootTable Loot;
    void Awake()
    {
        Healt = maxHealth.intiualValue; // Lấy Máu Hiện Tại
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        if(PosstionRes != Vector3.zero)
        {
            transform.position = PosstionRes;
        }
        
    }


    // Hàm Nhận Damge
    public void TakeDamge(float TDamge)
    {
        Healt -= TDamge;
        if(Healt <= 0)
        {
            EnemyDeath();
            FallOut_Inventory(); // Gọi rơi ra vật phẩm
            gameObject.SetActive(false);
            if(EnemyRom != null)
            {
                EnemyRom.Rasie();
            }
           
           
        }
    }

    // Hiệu ứng rơi ra vật phẩm
    public void FallOut_Inventory()
    {
        if(Loot != null)
        {
            // Tạo một cái Prefabs giả của một đối tượng
            PowerUp thisloot = Loot.Fallout();
            if(thisloot != null)  // Nếu không trả về null thì gọi hàm này
            {
                Instantiate(thisloot.gameObject,transform.position,quaternion.identity);
            }
        }
    }
    

    // Hiệu ứng chết
    public void EnemyDeath()
    {
        if(effect != null)
        {
            GameObject DeatEffect = Instantiate(effect,transform.position,quaternion.identity);
            Destroy(DeatEffect,1f); 
        }
    }


    public void CheckThoiGian(Rigidbody2D My, float ThoiGian)
    {
       
        // TakeDamge(damge);
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DungLai(My,ThoiGian));
        }
    }


    private IEnumerator DungLai(Rigidbody2D Myrigibody,float ThoiGianDung)
    {
        if(Myrigibody != null)
        {
            yield return new WaitForSeconds(ThoiGianDung);
            Myrigibody.linearVelocity = new Vector2(0,0);
            Myrigibody.bodyType = RigidbodyType2D.Dynamic; // Bật lại nó kh có chịu tắc động vật lí chỉ phát hiện va chạm
            Myrigibody.GetComponent<Enemy>().CurrState = EnemyState.Idle; // Khi Bị Choán Nó Sẽ Ngồi Im
        }
    }
}
