using UnityEngine;

public class ItemHeart : PowerUp
{
    [SerializeField] public FloatValue Heartmanager;

    [SerializeField] public FloatValue PlayerManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Heartmanager.Runtime +=1;
            PlayerManager.Runtime = Heartmanager.Runtime *2;
            // Singal để gọi hàm cập nhâp
            ItemSingal.Rasie();  
            Destroy(this.gameObject);
        }
    }
}
