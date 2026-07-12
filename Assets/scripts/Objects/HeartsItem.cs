using UnityEngine;

public class HeartsItem : PowerUp
{
  [SerializeField] private FloatValue HeartPlayer; // Máu Tối Đa Của Player
  [SerializeField] private float Acotum; // Máu Mỗi Khi Cộng Dồn
  [SerializeField] private FloatValue HeartMax; // Máu chỉ đc nhận bao nhiêu

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger) // !other.isTrigger nó chỉ tính vùng va chạm của collier thật của Player
        {
            HeartPlayer.Runtime += Acotum; // Cộng Máu Dồn Người Chơi Vào
            if(HeartPlayer.Runtime >= HeartMax.intiualValue * Acotum)  // Không Cho Vượt Mức Nếu Tim Đang Đầy
            {
                HeartPlayer.Runtime = HeartMax.intiualValue * Acotum;
                
            }
            ItemSingal.Rasie();
            Destroy(this.gameObject);

        }
    }


}
