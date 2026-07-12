using UnityEngine;
using UnityEngine.Rendering;

public class HealtIReactions : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;  // Tham chiếu đến biến sức khỏe của người chơi
    [SerializeField] private Signal HealthSignal;  // Tín hiệu để thông báo khi sức khỏe thay đổi

    public void UseHealthItem(float healAmout)
    {
      
        playerHealth.Runtime += healAmout; // Tăng sức khỏe của người chơi lên theo lượng hồi máu
        if(playerHealth.Runtime > playerHealth.intiualValue)
        {
            playerHealth.Runtime = playerHealth.intiualValue; // Đảm bảo sức khỏe không vượt quá giá trị tối đa
        }
        HealthSignal.Rasie();
    }
}
