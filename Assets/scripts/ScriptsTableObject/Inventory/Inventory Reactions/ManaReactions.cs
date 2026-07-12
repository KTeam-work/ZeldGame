using UnityEngine;
using UnityEngine.UI;

public class ManaReactions : MonoBehaviour
{
    [SerializeField] private FloatValue manaSolider;  // Tham chiếu đến biến sức khỏe của người chơi
    [SerializeField] private Signal ManaSignal;  // Tín hiệu để thông báo khi sức khỏe thay đổi
    [SerializeField] private Invetory magicSlider;
    public void UseManaItem(float ManaAmout)
    {
      
        manaSolider.Point += ManaAmout; // Tăng sức khỏe của người chơi lên theo lượng hồi máu
        
        if(manaSolider.Point > magicSlider.Maxslider)
        {
            manaSolider.Point = magicSlider.Maxslider; // Đảm bảo sức khỏe không vượt quá giá trị tối đa
        }
        ManaSignal.Rasie();
    }
}
