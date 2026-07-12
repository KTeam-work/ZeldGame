
using System.IO;
using UnityEngine;

public class NPC : SignBang
{
    [Header("Player")]
    public Rigidbody2D myRigibody;
    public Transform myTranform;
    public float Speed;

    private Vector3 Direction;
    
    public Collider2D col;

    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        Direction = Vector3.zero;
        ChangeDirection();
    }

    public override void Update()
    {
        base.Update(); // gọi làm hàm cha trước
        Vector2 tem = myTranform.position + Direction.normalized * Speed * Time.deltaTime;
        if (col.bounds.Contains(tem) && !PlayerIs)  // Nếu có trong giới hạn
        {
            AnimationPlayer();
            myRigibody.MovePosition(tem);

        }
        else if(!PlayerIs)
        {
            Vector3 temp = Direction;
            do
            {
                ChangeDirection();
            }while(temp == Direction);
        }
      
        
    }

  

    // Animation Player
    public void AnimationPlayer()
    {
        ani.SetFloat("MoveX",Direction.x);
        ani.SetFloat("MoveY",Direction.y);
    }


    // Random Hướng
    public void ChangeDirection()
    {
        
        int dir = Random.Range(0,4);
        switch (dir)
        {
            case 0: // Right
              Direction = Vector3.right;
              break;
            case 1:  // Up
              Direction = Vector3.up;
              break;
            case 2:  // Left
              Direction = Vector3.left;
              break;
            case 3:  // Down
              Direction = Vector3.down;
              break;
           
        }
        
    }
}
