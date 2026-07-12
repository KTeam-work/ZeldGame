using System.Collections;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class PlayerMonover : MonoBehaviour
{
    [Header("Player Info")]
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction arrowAttack;

    private InputAction AblityDash;
    private InputAction Button_BallProjectile;

    [Header("Move")]
   
    [SerializeField] float speed;
    private Rigidbody2D Mybody;
    private Vector3 change; // Để biết xác định người chơi nhấn nút nào
    private Animator animator;

    // State Machine
    public Statemachine Currstate;
    
    // 4 cái hoạt ảnh
    [SerializeField] GameObject rightHitBox;
    [SerializeField] GameObject leftHitBox;
    [SerializeField] GameObject upHitBox;
    [SerializeField] GameObject downHitBox; 

    [Header("Player Position")]
    private Vector3 LastH;
    public PlayerPosition p;

    [Header("Invetory")]
    [SerializeField] private Item Bow;

    // TODO Iventory
    public Invetory PlayerIve;  // Lưu Thông Tin Vật Phẩm Nhặt Được

    public SpriteRenderer spriteIve;  // Để Lưu Ảnh Cho Sau Này Khi Mở cái j đó

    // ToDO ABILITY
    [Header("Projectile")]
    public GameObject ArrowProjectile;

    // ToDo Magic
    public Signal SliderMagic;

    [Header("Ability")]
    public GenericAbiity DashAbiity;
    public GenericAbiity BallProjectile;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
        arrowAttack = playerInput.actions["Mele_Attack"];
        AblityDash = playerInput.actions["Dash"];
        Button_BallProjectile = playerInput.actions["Ball_P"];

        
        Mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        LastH = Vector3.down;
        if(transform.position == Vector3.zero)  // Nếu Vị Trí Người Chơi = 0 Thì Lấy Vị Trí Lưu Trong Player Position
        {
            transform.position = p.intiualValue;
        }
        
       
    }


  
    void Update()
    {
        if(Currstate.CurrPlayerState  == Statemachine.PlayerState.Interact)  // Đang trạng thái tương tác thì cho quay về
        {
            return;
        }
     
        change = Vector3.zero;
        Vector2 move = moveAction.ReadValue<Vector2>();
        change = new Vector3(move.x, move.y, 0);
        if(change != Vector3.zero)
        {
            LastH = change.normalized;
        }

        GetTriggerAttack();
    }

    void UpdateMove()
    {
        if(change != Vector3.zero)
        {
            Mover();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("MoveX",change.x);
            animator.SetFloat("MoveY",change.y);
            animator.SetBool("Moving",true);  // Nếu có di chuyển dựa vào true
        } 
        else
        {
            animator.SetBool("Moving",false); // Nếu không di chuyển tắt thành Flase
        }
    }

    // hàm di chuyển
    void Mover()
    {
        
        if((Currstate.CurrPlayerState == Statemachine.PlayerState.walk || Currstate.CurrPlayerState == Statemachine.PlayerState.idle) && change != Vector3.zero)
        {
            Currstate.CurrPlayerState = Statemachine.PlayerState.walk;
            // MovePosition : Bào Gồm(Vị Trí Hiện Tại + Hướng * Speed * Time.FixeDeltaTime)
            Vector3 newMove = transform.position + change.normalized * speed * Time.fixedDeltaTime;
            Mybody.MovePosition(newMove);
                
        }
       
    }
      
    public void GetTriggerAttack()
    {
        if(attackAction.triggered && Currstate.CurrPlayerState != Statemachine.PlayerState.attack && Currstate.CurrPlayerState != Statemachine.PlayerState.stagger)
        {
            StartCoroutine(UpdateAttack());
        }
        // ToDO ABILITY
        else if(arrowAttack.triggered && Currstate.CurrPlayerState != Statemachine.PlayerState.attack && Currstate.CurrPlayerState != Statemachine.PlayerState.stagger)
        {
            if (PlayerIve.CheckBow(Bow))  // Phải có cung thì mới cho bắn
            {
                // Todo Ability
                // gọi hàm bắn cung ra
                StartCoroutine(UpdateArrow_Attack());
            }
        }
        else if(AblityDash.triggered && Currstate.CurrPlayerState != Statemachine.PlayerState.stagger && Currstate.CurrPlayerState != Statemachine.PlayerState.attack)
        {
            // ToDO ABILITY
            // gọi hàm dash ra
            StartCoroutine(UpdateDash());
        }
        else if(Button_BallProjectile.triggered && Currstate.CurrPlayerState !=Statemachine.PlayerState.stagger && Currstate.CurrPlayerState != Statemachine.PlayerState.attack)
        {
            StartCoroutine(UpdateBall_Projectile());
        }
        else 
        {
            UpdateMove();
        }
    }


    // Hàm Bật HitBox Khi Tấn Công
    void EnableDestroyBot()
    {
        DisableDestroyBox();

        if(LastH.x > 0.5f)
        {
            rightHitBox.SetActive(true);
        }else if(LastH.x < -0.5f)
        {
            leftHitBox.SetActive(true);
        }else if(LastH.y > 0.5f)
        {
            upHitBox.SetActive(true);
        }
        else if(LastH.y < -0.5f)
        {
            downHitBox.SetActive(true);
        }
    }


    void DisableDestroyBox()
    {
        rightHitBox.SetActive(false);
        leftHitBox.SetActive(false);
        upHitBox.SetActive(false);
        downHitBox.SetActive(false);
    }

    
  
    // Hàm Tấn Công bằng Sowrd
    public IEnumerator UpdateAttack()
    {
        animator.SetBool("Attack",true);
        Currstate.CurrPlayerState = Statemachine.PlayerState.attack;
        EnableDestroyBot();
        yield return new WaitForSeconds(0.3f);

        DisableDestroyBox();
        
        animator.SetBool("Attack",false);
        yield return new WaitForSeconds(0.3f);
        if(Currstate.CurrPlayerState != Statemachine.PlayerState.Interact)  // check độ ưu tiên khi chém 
        {
            Currstate.CurrPlayerState = Statemachine.PlayerState.walk; // Sau Khi Tấn Công Xong Thì Chuyển Thành Trạng Thái Đứng Yên
        }
       
    }
    
    // ToDO ABILITY
    public IEnumerator UpdateArrow_Attack()
    {
        
        Currstate.CurrPlayerState = Statemachine.PlayerState.attack;
       
        yield return new WaitForSeconds(0.3f);

        MakeArrow();
        
        
        yield return new WaitForSeconds(0.3f);
        if(Currstate.CurrPlayerState != Statemachine.PlayerState.Interact)  // check độ ưu tiên khi chém 
        {
            Currstate.CurrPlayerState = Statemachine.PlayerState.walk; // Sau Khi Tấn Công Xong Thì Chuyển Thành Trạng Thái Đứng Yên
        }
       
    }


    // TOADO ABILITY
    // Make Arrow at the player
    private void MakeArrow()
    {
       if(PlayerIve.SliderPoint.Point > 0)
        {
            // Take Direction from Cache
            Vector2 tem = new Vector2(animator.GetFloat("MoveX"),animator.GetFloat("MoveY"));
            Arrow_Projectile arrow = Instantiate(ArrowProjectile,transform.position,Quaternion.identity).GetComponent<Arrow_Projectile>();
            PlayerIve.ReducerMagic();  // Giảm thanh mana xuống
            SliderMagic.Rasie();
            arrow.Setup(tem,MakeRotation()); // Direction và Rotation Angles
        }
    }

    // TODO ABILITY
    // Make Rotation
    public Vector3 MakeRotation()
    {
        // Tính góc quay dựa trên Rad và đồng thời nhân với mathf.Rad2Deg để chuyển sang độ 
        float tem = Mathf.Atan2(animator.GetFloat("MoveY"),animator.GetFloat("MoveX")) * Mathf.Rad2Deg;
        return new Vector3(0,0,tem);
    }


    public IEnumerator UpdateDash()
    {
        Currstate.CurrPlayerState = Statemachine.PlayerState.ability;
        DashAbiity.UseAbility(transform.position,LastH,animator,Mybody);
        yield return new WaitForSeconds(DashAbiity.duration);
        Mybody.linearVelocity = Vector2.zero;
        Currstate.CurrPlayerState = Statemachine.PlayerState.idle; // Sau Khi Tấn Công Xong Thì Chuyển Thành Trạng Thái Đứng Yên
    }


    public IEnumerator UpdateBall_Projectile()
    {
        Currstate.CurrPlayerState = Statemachine.PlayerState.ability;
        BallProjectile.UseAbility(transform.position,LastH,animator,Mybody);
        yield return new WaitForSeconds(BallProjectile.duration);
        Currstate.CurrPlayerState = Statemachine.PlayerState.idle;
    }

    // Để Gọi Hành Động Khi Mở Một J Đó
    public void RasieIve()
    {
        if(Currstate.CurrPlayerState != Statemachine.PlayerState.Interact)
        {
            animator.SetBool("Rev",true);
            spriteIve.sprite = PlayerIve.CurrItem.sprite;
            Currstate.CurrPlayerState = Statemachine.PlayerState.Interact;
        }
        else
        {
            animator.SetBool("Rev",false);
            Currstate.CurrPlayerState = Statemachine.PlayerState.idle;
            spriteIve.sprite = null;
        }
       
    }

}
