using System.Collections;
using UnityEngine;

public class MeleEnemy : Log
{

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Target.position);
    }
    public override void CheckTarget()
    {   // Trong Phạm Vi Truy Đuổi Và Phải Lớn Hơn Phạm Vi Tấn Công
       
        if(Vector3.Distance(transform.position,Target.position) < ChaseRaduis && Vector3.Distance(transform.position,Target.position) > AttackRaduis )
        {
            
           if(CurrState == EnemyState.Idle || CurrState == EnemyState.Walk && CurrState != EnemyState.Stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,Target.position,Speed * Time.deltaTime);
                mybody.MovePosition(temp);
                ChangeState(EnemyState.Walk);
                ani.SetBool("Walk",true);
                SetAni(temp - transform.position);
                
            }
        }  // Nếu đã đến gần
        else if(Vector3.Distance(transform.position, Target.position) < AttackRaduis)
        {
            if(CurrState != EnemyState.Attack) // phải check điều kiện khác thì không được chém
            {
                StartCoroutine(CheckAttcak()); // Gọi Hàm chém
            }
        }
        else
        {
            ani.SetBool("Walk",false); // Còn Lại là đứng yên
        }
    }


    public IEnumerator CheckAttcak()
    {
        CurrState = EnemyState.Attack;
        ani.SetBool("Attack",true);
        yield return new WaitForSeconds(1f); // Chời hết 1 h rùi kết thúc hành động chém
        ani.SetBool("Attack",false);
        CurrState = EnemyState.Walk;
    }
}
