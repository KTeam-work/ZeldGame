
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public FloatValue HeartStart;

    public FloatValue PlayerHeart;
    public Image[] Hearts; // Mảng chứa các hộp tim

    // Tham chiếu đến 3 trạng thái máu
    public Sprite fullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;


    void Start()
    {
        InvitiHeart();
    }


    public void InvitiHeart()
    {
        // Duyệt Mấy Cục Máu Mình Cần
        for(int i = 0; i < HeartStart.Runtime; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Hearts[i].sprite = fullHeart;
        }
    }


    public void UpdateHeart()
    {
        InvitiHeart(); // Gọi để cập nhập khi ăn được 1 cục máu (Không phải hồi máu)
        float heath = PlayerHeart.Runtime;
        for(int i = 0; i < HeartStart.Runtime; i++)
        {
            if(heath >= 2)
            {
                
                Hearts[i].sprite = fullHeart;
                heath -=2; // Trừ đi 2 vì mỗi 1 tim là 2 máu
            }else if(heath == 1)
            {
               
                Hearts[i].sprite = HalfHeart;
                heath -= 1;
            }
            else
            {
              
                Hearts[i].sprite = EmptyHeart;
                
            }
        }
        
    }


}
