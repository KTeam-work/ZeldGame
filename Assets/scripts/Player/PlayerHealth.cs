using UnityEngine;
using System.Collections;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private Signal healthSiganl; // Tín hiệu để thông báo khi sức khỏe thay đổi
    [SerializeField] CameraKick cameraKick; // Tham chiếu đến CameraKick để kích hoạt hiệu ứng khi nhận sát thương
    [SerializeField] private FlashAni flash;
    [SerializeField] private Statemachine Currstate;
    
    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        Debug.Log("Player nhận sát thương: " + damageAmount);
        maxHealth.Runtime = currenHealth;
        healthSiganl.Rasie(); // Gọi tín hiệu để cập nhật trạng thái sức khỏe
        
    }

    public void PlayerStagger(float ThoGian,Rigidbody2D My)
    {
        StartCoroutine(DungLai(ThoGian,My));
        
    }
    
    
    // Dành Cho Player
    private IEnumerator DungLai(float ThoiGianDung, Rigidbody2D Mybody)
    {
        // ToDoCamera Kick
        cameraKick.ScreenKick();
        if(Mybody != null)
        {
            flash.Flash();
            yield return new WaitForSeconds(ThoiGianDung);
            Mybody.linearVelocity = new Vector2(0,0);
            Mybody.bodyType = RigidbodyType2D.Dynamic; // Bật lại nó kh chịu tắc động vật lí chỉ phát hiện va chạm
            Currstate.CurrPlayerState = Statemachine.PlayerState.idle; // Khi Bị Choán Nó Sẽ Ngồi Im
        }
    }



}
