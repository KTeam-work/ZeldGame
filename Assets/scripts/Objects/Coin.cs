using UnityEngine;


public class Coin : PowerUp
{
    public Invetory Playerive;
    public void Start()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Playerive.CoinPoint +=1;
            ItemSingal.Rasie();
            Destroy(this.gameObject);
        }
    }
}
