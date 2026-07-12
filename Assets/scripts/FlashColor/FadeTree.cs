using System;
using UnityEngine;

public class FadeTree : MonoBehaviour
{
    private SpriteRenderer myRender;
    
    [SerializeField] private float Apla;

    void Start()
    {
        myRender = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetAlpha(Apla);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetAlpha(1f);
        }
    }

    public void SetAlpha(float aphal)
    {
        Color c = myRender.color;
        c.a = aphal;
        myRender.color = c;
    }
}
