using UnityEngine;
using System.Collections;

public class FlashAni : MonoBehaviour
{
    [Header("Invulnerabili Frames")]
    [SerializeField] private Color flashColor;
    [SerializeField] private Color RegularColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private int NumberofFlash; // Số Lần Nhấp Nhá
    [SerializeField] private Collider2D  Mycolider; // Phát Hiện Va Chạm
    [SerializeField] private SpriteRenderer mysprite;

    public void Flash()
    {
        StartCoroutine(FlashFarme());
    }

     private IEnumerator FlashFarme()
    {
        int number = 0;
        Mycolider.enabled = false; // tắt đi cái trạng thái khi bị nhấp nhá, không cho phát hiện va trạm nào nx
        while(number < NumberofFlash)
        {
            mysprite.color = flashColor; // Nhận màu
            yield return new WaitForSeconds(flashDuration); // Thời Gian Thực Thi FlashColor
            mysprite.color = RegularColor;
            yield return new WaitForSeconds(flashDuration);
            number++;
        }
        Mycolider.enabled = true;
    }
}
