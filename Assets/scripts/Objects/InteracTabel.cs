using UnityEngine;

public class InteracTabel : MonoBehaviour
{
    public Signal ContextOn;

    public string Name;
    public bool PlayerIs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ContextOn.Rasie();
            PlayerIs = true;
        }
    }

    public virtual void  OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ContextOn.Rasie(); // Gọi Tắt Cái Hiện Trên Đầu
            PlayerIs = false;
            
        }
    }
}
