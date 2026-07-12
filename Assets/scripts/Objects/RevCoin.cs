using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RevCoin : MonoBehaviour
{
   
    public Invetory PlayerIve;  // Để + Coin Vào Kho Đồ
    public TMP_Text TextCoin;  // Hiện Chữ
    public void Start()
    {
        TextCoin.text = PlayerIve.CoinPoint.ToString();
    }

    public void RecitemCoin()
    {
       
        TextCoin.text =  PlayerIve.CoinPoint.ToString();
    }
}
