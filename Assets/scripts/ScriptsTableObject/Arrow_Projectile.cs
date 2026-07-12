using UnityEngine;

public class Arrow_Projectile : MonoBehaviour
{
    [Header("Tốc độ")]
    public float Speed;
    [Header("Trọng Lực")]
    public Rigidbody2D myRigi;

    public float LifeTime;
    private float LastTime;

    void Start()
    {
        LastTime = LifeTime; // thời gian sống
    }
    // Update is called once per frame
    void Update()
    {
        LastTime -= Time.deltaTime;
        if(LastTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void Setup(Vector2 vecl, Vector3 direction)
    {
        myRigi.linearVelocity = vecl.normalized * Speed; // Tốc độ khi bắn
        transform.rotation = Quaternion.Euler(direction);  // để cho cung nó xoay đúng hướng khi bắn
    }


    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Enemy") || Other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
