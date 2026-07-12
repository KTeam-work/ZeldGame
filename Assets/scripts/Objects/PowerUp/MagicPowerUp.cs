using UnityEngine;

public class MagicPowerUp : PowerUp
{
    public Invetory Magicpower;
    public void OnTriggerEnter2D(Collider2D  Other)
    {
        if (Other.CompareTag("Player"))
        {
            
            Magicpower.SliderPoint.Point += 2; // cộng lên thay
            ItemSingal.Rasie();
            Destroy(this.gameObject); // gọi raise
        }
    }
}
