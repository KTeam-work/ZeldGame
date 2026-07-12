using Unity.VisualScripting;
using UnityEngine;

public class Log : Enemy
{
    public Transform Target;
    public float ChaseRaduis;  // Bán Kính Đuổi
    public float AttackRaduis; // Bán Kính Tấn Công
     
    public Rigidbody2D mybody;
    public Transform Homepostion;

    public Animator  ani;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrState = EnemyState.Idle;
        Target = GameObject.FindWithTag("Player").transform; // Tìm Đối Tượng Có Thẻ Là Player
        mybody =  GetComponent<Rigidbody2D>();
        ani  = GetComponent<Animator>();
        ani.SetBool("Wake",true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    public virtual void CheckTarget()
    {   // Trong Phạm Vi Truy Đuổi Và Phải Lớn Hơn Phạm Vi Tấn Công
        if(Vector3.Distance(transform.position,Target.position) < ChaseRaduis && Vector3.Distance(transform.position,Target.position) > AttackRaduis )
        {
           if(CurrState == EnemyState.Idle || CurrState == EnemyState.Walk && CurrState != EnemyState.Stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,Target.position,Speed * Time.deltaTime);
                mybody.MovePosition(temp);
                ChangeState(EnemyState.Walk);
                ani.SetBool("Wake",true);
                SetAni(temp - transform.position);
                
            }
        }
        else
        {
            ani.SetBool("Wake",false);
        }
    }


    // Hàm Để Chuyển Animator
    public void SetAni(Vector2 dis)
    {
        ani.SetFloat("MoveX",dis.x);
        ani.SetFloat("MoveY",dis.y);
    }


    
    public void ChangeState(EnemyState NewEnemy)
    {
        if(CurrState != NewEnemy)
        {
            CurrState = NewEnemy;
        }
    }
}
