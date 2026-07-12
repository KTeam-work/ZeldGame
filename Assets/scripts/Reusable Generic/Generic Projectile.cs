using UnityEngine;

public class GenericProjectile : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D myRigibody;

    void Awake()
    {
        myRigibody = GetComponent<Rigidbody2D>();
    }
    public void SetUp(Vector2 Direction)
    {
        myRigibody.linearVelocity = Direction.normalized * Speed;
        Destroy(this.gameObject,3f);
    }


    void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
