using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyTurret : Log
{
    public GameObject Projectile; // Để tạo ra một instantice
     
    public float FireDelay; // thời gian bắn đạn ra

    private float FireDelaySecond;
    [SerializeField] private bool canFire;

    void Start()
    {
        FireDelaySecond = FireDelay;
        ani =GetComponent<Animator>();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Target.position);
    }

    void Update()
    {
        if(canFire == false)
        {
            FireDelaySecond -= Time.deltaTime;
            if(FireDelaySecond <= 0)
            {
                canFire = true;
            
            }
        }
        ani.SetBool("Wake",true);
        CheckTarget();
    }



    public override void CheckTarget()
    {   // Trong Phạm Vi Truy Đuổi Và Phải Lớn Hơn Phạm Vi Tấn Công
        if(Vector3.Distance(transform.position,Target.position) < ChaseRaduis && Vector3.Distance(transform.position,Target.position) > AttackRaduis )
        {
           if(CurrState == EnemyState.Idle || CurrState == EnemyState.Walk && CurrState != EnemyState.Stagger)
            {

                if (canFire)  // Hết thời gian có thể bắng lại
                {
                      
                    Vector3 Vitri= Target.transform.position - transform.position;
                    SetAni(Vitri);
                    // Viên đạn nên xuất hiện tại vị trí mình
                    GameObject Current = Instantiate(Projectile,transform.position,Quaternion.identity);
                    Current.GetComponent<Projectile>().Launch(Vitri);
                    canFire = false;
                    FireDelaySecond = FireDelay;
                }   
            }
        }
      
    }
}
