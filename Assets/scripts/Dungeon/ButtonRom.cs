using UnityEngine;

public class ButtonRom : MonoBehaviour
{
    public bool active;
    public BoolValue Bol;
    private SpriteRenderer Myspr;

    public Sprite spr;

    public RomDoor Door;

    public GameObject Tranfer;


    public void Start()
    {
        Myspr = GetComponent<SpriteRenderer>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && active == false) // Đảm bảo chạm vào là Player và Active là False
        {
           Active();
        }
    }


    public void Active()
    {
        active = true;
        Bol.RunTime = active;
        Myspr.sprite = spr; // Dán Ảnh Khi Mở Nút
        Door.OpenDoor();  // Gọi Để Mở Cửa
        Tranfer.SetActive(true);
    }
}
