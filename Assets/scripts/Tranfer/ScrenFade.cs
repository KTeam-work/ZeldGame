
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrenFade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image Fadeimage;
    public float speed = 0.6f;
    void Start()
    {
        Fadeimage.color = new Color(0,0,0,0);
        StartCoroutine(FadeIn());
    }
    
    // Khi Ra Ngoai
    public IEnumerator FadeOut()
    {
        float a = 0;
        while(a < 1)
        {
            a += Time.deltaTime * speed; // Để tăng tốc độ tối
            Fadeimage.color = new Color(0,0,0,a);
            yield return null;
        }

    }

    // Khi Vào Trong
    public IEnumerator FadeIn()
    {
        float a =1;
        while(a > 0)
        {
            a -= Time.deltaTime * speed;
            Fadeimage.color = new Color(0,0,0,a);
            yield return null;
        }
    }

}
