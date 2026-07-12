using UnityEngine;

public class NPCPatrol : Log
{

   public Transform[] Path;
   private int point;

   public Transform GoalCurrent;

   public float CurrTuan;

   public override void CheckTarget()
    {   
        if(Vector3.Distance(transform.position,Target.position) < ChaseRaduis && Vector3.Distance(transform.position,Target.position) > AttackRaduis )
        {
           if(CurrState == EnemyState.Idle || CurrState == EnemyState.Walk && CurrState != EnemyState.Stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,Target.position,Speed * Time.deltaTime);
                mybody.MovePosition(temp);
                ChangeState(EnemyState.Walk);
                // ani.SetBool("Wake",true);
                SetAni(temp - transform.position);
                
            }
        }// Nếu Không Trong Phạm Vi Tấn Công Thì Trở Về Điểm
        else if(Vector3.Distance(transform.position,Target.position) > ChaseRaduis)  // Lớn Hơn Điểm Chase
        {
            if(Vector3.Distance(transform.position,Path[point].position) > CurrTuan)  // Coi Thử Quái Đến Gần Điểm Chx, Nếu chx thì đi tiếp
            {
                
                // Trở về điểm hiện tại
                Vector3 tmp = Vector3.MoveTowards(transform.position,Path[point].position,Speed * Time.deltaTime);
                mybody.MovePosition(tmp);
                SetAni(tmp - transform.position);
            }
            else  // Nếu Quái Đi Đến Điểm Mục Tiêu Đổi Mục Tiêu
            {
                ChangePatrol();
            }
        }
      
       
    }


    // Hàm Tính Lộ Trình Các Điểm Đến Đó
    public void ChangePatrol() // 0, 1 ,2 
    {
        if(point == Path.Length - 1) // Là Cấp 0
        {
            point = 0;
            GoalCurrent = Path[0];
        }
        else  // Nó sẽ chạy đây đầu tiên
        {
            point++;
            GoalCurrent = Path[point];
        }
    }
}
