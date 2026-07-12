using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class AreaEnemy : Log
{
    public Collider2D box;

    public override void CheckTarget()
    {   // Trong Phạm Vi Truy Đuổi Và Phải Lớn Hơn Phạm Vi Tấn Công
        if(Vector3.Distance(transform.position,Target.position) < ChaseRaduis && Vector3.Distance(transform.position,Target.position) > AttackRaduis
            && box.bounds.Contains(Target.transform.position))  // Kiểm Tra Nó Có Nằm Trong Vùng Đó Không
        {
           if(CurrState == EnemyState.Idle || CurrState == EnemyState.Walk && CurrState != EnemyState.Stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,Target.position,Speed * Time.deltaTime);
                mybody.MovePosition(temp);
                ChangeState(EnemyState.Walk);
                ani.SetBool("Wake",true);
                SetAni(temp - transform.position);
                
            }
        } // Nếu Phạm Vị Tấn Công Xa Hay Người Chơi Ra Khỏi Ô Tấn Công Thì Quay Lại
        else if(Vector3.Distance(Target.position,transform.position) > ChaseRaduis || !box.bounds.Contains(Target.transform.position))
        {
            ani.SetBool("Wake",false);
        }
    }
}
